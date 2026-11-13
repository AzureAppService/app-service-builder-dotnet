#!/usr/bin/env bash
set -euo pipefail

cd "$(dirname "$0")/.."
if ! grep -Fq 'https://builder.appservice.azure.com/docs/' README.md ||
    grep -Fq 'https://builderapps.azure.com/docs' README.md; then
    printf 'README documentation links must use the canonical docs host.\n' >&2
    exit 1
fi
port=${SMOKE_TEST_PORT:-8080}
if [[ ! "$port" =~ ^[0-9]+$ ]] || ((port < 1024 || port > 65535)); then
    printf 'SMOKE_TEST_PORT must be an available port from 1024 to 65535.\n' >&2
    exit 1
fi
listen_url="http://0.0.0.0:$port"
endpoint_env=()
if [[ "$port" != 8080 ]]; then
    # A test-only Kestrel endpoint avoids disrupting a shared port 8080 listener.
    listen_url="http://127.0.0.1:$port"
    endpoint_env=("Kestrel__Endpoints__Smoke__Url=$listen_url")
fi
base_url="http://127.0.0.1:$port"
dotnet publish -c Release -o bin/sample-publish --configfile NuGet.Config

smoke_dir=bin/smoke-test
mkdir "$smoke_dir"
app_pid=""

stop_app() {
    if [[ -n "$app_pid" ]]; then
        if kill -0 "$app_pid" 2>/dev/null; then
            kill "$app_pid"
        fi
        if wait "$app_pid"; then
            app_pid=""
        else
            local status=$?
            app_pid=""
            printf 'Sample process exited unexpectedly with status %s\n' "$status" >&2
            return 1
        fi
    fi
}

cleanup() {
    local status=$?
    if ! stop_app; then
        status=1
    fi
    rm -f "$smoke_dir/app.log" "$smoke_dir/body" "$smoke_dir/headers"
    rmdir "$smoke_dir"
    return "$status"
}
trap cleanup EXIT

assert_response() {
    local path=$1 expected_status=$2 expected_body=$3 method=${4:-GET} status
    if [[ "$method" == HEAD ]]; then
        status=$(curl --silent --show-error --max-time 5 --head \
            --dump-header "$smoke_dir/headers" --output /dev/null \
            --write-out '%{http_code}' "$base_url$path")
        : > "$smoke_dir/body"
    else
        status=$(curl --silent --show-error --max-time 5 \
            --request "$method" --dump-header "$smoke_dir/headers" \
            --output "$smoke_dir/body" --write-out '%{http_code}' "$base_url$path")
    fi
    if [[ "$status" != "$expected_status" ]] ||
        ! printf '%s' "$expected_body" | cmp -s - "$smoke_dir/body"; then
        printf 'Unexpected response for %s: HTTP %s\n' "$path" "$status" >&2
        cat "$smoke_dir/body" >&2
        return 1
    fi
    if ! kill -0 "$app_pid" 2>/dev/null; then
        printf 'Sample process exited during HTTP validation\n' >&2
        cat "$smoke_dir/app.log" >&2
        return 1
    fi
}

assert_home() {
    local path=$1 status
    status=$(curl --silent --show-error --max-time 5 \
        --dump-header "$smoke_dir/headers" --output "$smoke_dir/body" \
        --write-out '%{http_code}' "$base_url$path")
    if [[ "$status" != 200 ]] ||
        ! grep -Fiq 'Content-Type: text/html; charset=utf-8' "$smoke_dir/headers" ||
        grep -Fiq 'Location:' "$smoke_dir/headers" ||
        ! grep -Fq '<!doctype html>' "$smoke_dir/body" ||
        ! grep -Fq '<title>.NET workbench | App Service Builder</title>' "$smoke_dir/body" ||
        ! grep -Fq "<h2>$encoded_greeting</h2>" "$smoke_dir/body" ||
        ! grep -Fq 'data-path="/"' "$smoke_dir/body" ||
        ! grep -Fq 'data-path="/health"' "$smoke_dir/body" ||
        ! grep -Fq 'aria-label="Check app health"' "$smoke_dir/body" ||
        ! grep -Fq 'id="customize"' "$smoke_dir/body" ||
        ! grep -Fq 'href="https://learn.microsoft.com/aspnet/core/"' "$smoke_dir/body" ||
        grep -Fq 'href="/health"' "$smoke_dir/body" ||
        ! grep -Fq 'href="https://builder.appservice.azure.com/docs/guides/variables/"' "$smoke_dir/body" ||
        grep -Fq 'https://builderapps.azure.com/docs' "$smoke_dir/body" ||
        grep -Fq '/demo' "$smoke_dir/body" ||
        grep -Fq 'must-not-appear-in-page' "$smoke_dir/body"; then
        printf 'Unexpected HTML response for %s (%s greeting): HTTP %s\n' "$path" "$mode" "$status" >&2
        return 1
    fi
}

for mode in unset empty custom encoded; do
    if curl --silent --max-time 1 --output /dev/null "$base_url/"; then
        printf 'Port %s is already serving HTTP; choose another SMOKE_TEST_PORT or stop your own process before testing.\n' "$port" >&2
        exit 1
    fi

    case "$mode" in
        unset) unset SAMPLE_GREETING; encoded_greeting="Hello" ;;
        empty) export SAMPLE_GREETING=""; encoded_greeting="Hello" ;;
        custom) export SAMPLE_GREETING="Welcome"; encoded_greeting="Welcome" ;;
        encoded) export SAMPLE_GREETING='<script>alert("hello")</script>&'; encoded_greeting='&lt;script&gt;alert(&quot;hello&quot;)&lt;/script&gt;&amp;' ;;
    esac

    : > "$smoke_dir/app.log"
    env "${endpoint_env[@]}" 'Logging__LogLevel__Microsoft.Hosting.Lifetime=Information' PRIVATE_TEST_VALUE=must-not-appear-in-page \
        dotnet bin/sample-publish/BuilderDotnetSample.dll >> "$smoke_dir/app.log" 2>&1 &
    app_pid=$!
    ready=false
    for ((attempt = 0; attempt < 100; attempt++)); do
        if ! kill -0 "$app_pid" 2>/dev/null; then
            break
        fi
        if grep -Fq "Now listening on: $listen_url" "$smoke_dir/app.log"; then
            ready=true
            break
        fi
        sleep 0.1
    done
    if [[ "$ready" != true ]]; then
        printf 'Sample failed to bind port %s within 10 seconds (%s greeting).\n' "$port" "$mode" >&2
        cat "$smoke_dir/app.log" >&2
        exit 1
    fi

    assert_home "/"
    assert_home "/?preview=1"
    assert_response "/health" 200 $'OK\n'
    grep -Fiq 'Content-Type: text/plain; charset=utf-8' "$smoke_dir/headers"
    assert_response "/health?check=1" 200 $'OK\n'
    assert_response "/not-found" 404 ""
    assert_response "/demo" 404 ""
    assert_response "/demo?preview=1" 404 ""
    assert_response "/" 405 "" POST
    grep -Fiq 'Allow: GET' "$smoke_dir/headers"
    assert_response "/health" 405 "" POST
    grep -Fiq 'Allow: GET' "$smoke_dir/headers"
    assert_response "/" 405 "" HEAD
    assert_response "/health" 405 "" HEAD
    stop_app
    printf 'Passed root HTML, escaped greeting, health, query, method, and 404 checks with %s SAMPLE_GREETING\n' "$mode"
done
