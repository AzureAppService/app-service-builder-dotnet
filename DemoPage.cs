using System.Text.Encodings.Web;

internal static class DemoPage
{
    internal static string Render(string greeting) =>
        Page.Replace("{{GREETING}}", HtmlEncoder.Default.Encode(greeting), StringComparison.Ordinal);

    private const string Page = """
<!doctype html>
<html lang="en">
<!--
THESIS: An honest request workbench, not an invented deployment dashboard.
OWN-WORLD: Plum navigation, pale mineral canvas, square code surfaces, system type.
STORY: Read the actual public greeting, inspect the contract, run an existing endpoint.
FIRST VIEWPORT: Narrow rail; large greeting on plum; compact runtime facts alongside;
endpoint rows and their Run buttons directly below.
FORM: Approved structured product workbench; restrained neutrals with a plum response field.
-->
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <meta name="theme-color" content="#39283f">
  <meta name="description" content="Explore the public greeting and HTTP endpoints of the App Service Builder ASP.NET sample.">
  <link rel="icon" href="data:,">
  <title>.NET workbench | App Service Builder</title>
  <style>
    :root {
      color-scheme: light;
      --ink: #29252e; --muted: #65606c; --plum: #633d71; --plum-deep: #39283f;
      --canvas: #f5f4f7; --line: #dedbe3; --white: #fff; --soft: #ede8f1;
    }
    * { box-sizing: border-box; }
    html { scroll-behavior: smooth; scroll-padding-top: 24px; }
    body { margin: 0; color: var(--ink); background: var(--canvas); font: 15px/1.6 -apple-system, BlinkMacSystemFont, "Segoe UI", sans-serif; }
    a { color: var(--plum); text-underline-offset: 4px; }
    a:hover { text-decoration-thickness: 2px; }
    button, a { -webkit-tap-highlight-color: transparent; }
    :focus-visible { outline: 3px solid #aa5bcc; outline-offset: 5px; }
    .skip { position: absolute; top: -80px; left: 20px; z-index: 3; background: white; padding: 12px 20px; }
    .skip:focus { top: 12px; }
    .shell { display: grid; grid-template-columns: 230px minmax(0, 1fr); min-height: 100vh; }
    .rail { background: var(--plum-deep); color: #eee5f2; padding: 35px 22px 24px; display: flex; flex-direction: column; }
    .brand { display: flex; align-items: center; gap: 12px; font-size: 15px; font-weight: 650; line-height: 1.3; }
    .brand-mark { display: grid; place-items: center; width: 42px; height: 42px; border: 1px solid #a48aae; border-radius: 9px; font-size: 12px; font-weight: 750; flex-shrink: 0; }
    .brand-logo { width: 18px; height: 18px; vertical-align: middle; margin-right: 6px; }
    .rail nav { display: grid; gap: 8px; margin-top: 62px; }
    .rail nav a { display: flex; align-items: center; gap: 13px; padding: 11px 14px; border-radius: 6px; color: #eee5f2; text-decoration: none; }
    .rail nav a:first-child { background: #5b4266; color: white; }
    .rail nav a:hover { background: #684e73; }
    .nav-symbol { font-size: 19px; width: 20px; text-align: center; line-height: 1; }
    .rail-foot { margin-top: auto; padding: 70px 12px 0; font-size: 12px; color: #d5c6dc; }
    .rail-foot strong { display: block; color: #f5edf8; margin-bottom: 5px; font-weight: 600; }
    .workspace { min-width: 0; padding: 0 52px 25px; max-width: 1510px; width: 100%; margin-inline: auto; }
    .topbar { display: flex; justify-content: space-between; align-items: center; min-height: 90px; border-bottom: 1px solid var(--line); gap: 18px; font-size: 13px; color: var(--muted); }
    .breadcrumb { display: flex; gap: 12px; align-items: center; flex-wrap: wrap; }
    .breadcrumb strong { color: var(--ink); font-weight: 600; }
    .intro { display: flex; justify-content: space-between; align-items: end; gap: 24px; margin: 37px 0 26px; }
    h1 { margin: 0 0 5px; font-size: 32px; line-height: 1.2; letter-spacing: -.035em; font-weight: 650; }
    .intro p { color: var(--muted); margin: 0; max-width: 65ch; }
    .runtime { font-weight: 650; font-size: 13px; white-space: nowrap; display: flex; align-items: center; gap: 9px; }
    .runtime span { background: #e7deed; color: #633d71; padding: 3px 8px; border-radius: 4px; }
    .overview { display: grid; grid-template-columns: minmax(0, 1.8fr) minmax(235px, 1fr); background: white; border: 1px solid var(--line); border-radius: 10px; overflow: hidden; }
    .greeting { background: #633d71; color: #f4eaf8; padding: 26px 32px 28px; min-height: 280px; display: flex; flex-direction: column; align-items: start; }
    .response-label { display: flex; justify-content: space-between; width: 100%; align-items: center; font-size: 12px; color: #e4d3ec; gap: 12px; }
    code, pre { font-family: ui-monospace, SFMono-Regular, Consolas, monospace; font-size: 13px; }
    .response-label code { color: white; border: 1px solid #a78bb5; border-radius: 4px; padding: 3px 8px; }
    .greeting h2 { font-size: 64px; line-height: 1.12; font-weight: 550; letter-spacing: -.035em; margin: 28px 0 18px; max-width: 100%; overflow-wrap: anywhere; color: white; }
    .greeting p { margin: auto 0 0; color: #eee0f4; font-size: 13px; }
    .greeting .public-note { margin-top: 5px; font-size: 12px; color: #e1cfe9; }
    .facts { padding: 25px 28px; }
    .facts h2 { font-size: 16px; font-weight: 650; margin: 0 0 17px; }
    dl { margin: 0; }
    .fact { display: flex; justify-content: space-between; gap: 16px; padding: 12px 0; border-top: 1px solid #ebe8ee; font-size: 13px; }
    dt { color: var(--muted); } dd { margin: 0; font-weight: 600; }
    .fact:last-child { padding-bottom: 0; }
    .section-heading { display: flex; justify-content: space-between; align-items: baseline; gap: 16px; margin: 32px 0 15px; }
    .section-heading h2 { font-size: 20px; letter-spacing: -.02em; margin: 0; font-weight: 650; }
    .section-heading p { font-size: 12px; color: var(--muted); margin: 0; }
    .endpoints { border: 1px solid var(--line); background: white; border-radius: 8px; overflow: hidden; }
    .endpoint { display: grid; grid-template-columns: 60px minmax(100px, 1fr) minmax(100px, 1.2fr) auto; gap: 16px; align-items: center; padding: 19px 24px; }
    .endpoint + .endpoint { border-top: 1px solid var(--line); }
    .method { color: #684276; background: #eee8f2; border-radius: 4px; padding: 3px 8px; text-align: center; font: 650 11px/1.7 ui-monospace, SFMono-Regular, Consolas, monospace; }
    .path { font-weight: 650; color: var(--ink); }
    .endpoint p { margin: 0; color: var(--muted); font-size: 13px; }
    button { font: 600 12px/1.6 -apple-system, BlinkMacSystemFont, "Segoe UI", sans-serif; color: var(--plum); border: 1px solid #d6c9df; border-radius: 5px; background: white; padding: 8px 14px; cursor: pointer; min-height: 40px; transition: background 150ms ease-out, border-color 150ms ease-out; }
    button:hover { background: var(--soft); border-color: #9c7bab; }
    button:active { background: #dfd1e6; }
    button:disabled { cursor: wait; background: #eee8f2; color: #716078; }
    .result { margin-top: 14px; border: 1px solid var(--line); border-radius: 7px; background: #f0eef3; padding: 14px 19px; }
    .result[hidden] { display: none; }
    .result-heading { display: flex; gap: 12px; align-items: center; font-size: 12px; font-weight: 600; }
    .result pre { white-space: pre-wrap; overflow-wrap: anywhere; margin: 10px 0 0; }
    .result[data-error="true"] { border-color: #a64b51; background: #fff1f1; color: #8a2931; }
    .next { display: flex; align-items: start; justify-content: space-between; gap: 25px; padding: 26px 0 23px; margin-top: 7px; border-bottom: 1px solid var(--line); }
    .next h2 { font-size: 16px; margin: 0 0 5px; font-weight: 650; }
    .next p { color: var(--muted); font-size: 13px; margin: 0; max-width: 65ch; }
    .next a { white-space: nowrap; font-size: 13px; font-weight: 600; margin-top: 3px; }
    footer { display: flex; justify-content: space-between; gap: 20px; padding-top: 20px; color: var(--muted); font-size: 11px; }
    @media (min-width: 1600px) { .workspace { padding-inline: 70px; } }
    @media (max-width: 1100px) {
      .shell { grid-template-columns: 190px minmax(0, 1fr); }
      .workspace { padding-inline: 30px; }
      .rail { padding-inline: 16px; }
      .overview { grid-template-columns: minmax(0, 1.4fr) minmax(220px, 1fr); }
      .greeting { padding-inline: 25px; }
      .facts { padding-inline: 22px; }
      .intro { align-items: start; }
    }
    @media (max-width: 760px) {
      .shell { display: block; }
      .rail { padding: 17px 22px; }
      .brand-mark { width: 36px; height: 36px; }
      .brand br { display: none; }
      .rail nav { display: flex; flex-wrap: wrap; gap: 5px; margin-top: 18px; }
      .rail nav a { padding: 7px 10px; font-size: 12px; }
      .nav-symbol, .rail-foot { display: none; }
      .workspace { padding-inline: 22px; }
      .topbar { min-height: 65px; font-size: 11px; gap: 8px; }
      .breadcrumb { gap: 7px; }
      .intro { margin-top: 28px; flex-wrap: wrap; gap: 14px; }
      h1 { font-size: 28px; }
      .intro p { font-size: 14px; }
      .overview { grid-template-columns: 1fr; }
      .greeting { min-height: 255px; padding: 22px; }
      .greeting h2 { font-size: 56px; }
      .facts { padding: 22px; }
      .section-heading { align-items: start; flex-direction: column; gap: 3px; }
      .endpoint { grid-template-columns: 48px minmax(0, 1fr) auto; gap: 12px; padding: 17px; }
      .endpoint p { grid-column: 2; grid-row: 2; font-size: 12px; }
      .endpoint button { grid-column: 3; grid-row: 1 / 3; }
      .method { padding-inline: 5px; }
      .next { flex-direction: column; gap: 13px; }
      footer { flex-direction: column; gap: 5px; padding-bottom: 8px; }
    }
    @media (prefers-reduced-motion: reduce) { html { scroll-behavior: auto; } button { transition: none; } }
  </style>
</head>
<body>
  <a class="skip" href="#main">Skip to content</a>
  <div class="shell">
    <aside class="rail" aria-label="Sample navigation">
      <div class="brand"><span class="brand-mark" aria-hidden="true">.NET</span><span><svg class="brand-logo" aria-hidden="true" focusable="false" width="18" height="18" viewBox="0 0 18 18" fill="none" xmlns="http://www.w3.org/2000/svg">
<g clip-path="url(#clip0_4575_347)">
<path d="M17.62 8.22L7.62 0.22C7.45 0.08 7.24 0 7 0C6.45 0 6 0.45 6 1C6 1.19 6.05 1.36 6.14 1.51L10.58 9L6.14 16.49C6.05 16.64 6 16.81 6 17C6 17.55 6.45 18 7 18C7.24 18 7.45 17.92 7.62 17.78L12.14 14.17L13.16 13.35L17.62 9.78C17.85 9.6 18 9.32 18 9C18 8.68 17.85 8.4 17.62 8.22Z" fill="url(#paint0_linear_4575_347)"/>
<path d="M17.62 8.22L7.62 0.22C7.45 0.08 7.24 0 7 0C6.45 0 6 0.45 6 1C6 1.19 6.05 1.36 6.14 1.51L10.58 9L6.14 16.49C6.05 16.64 6 16.81 6 17C6 17.55 6.45 18 7 18C7.24 18 7.45 17.92 7.62 17.78L12.14 14.17L13.16 13.35L17.62 9.78C17.85 9.6 18 9.32 18 9C18 8.68 17.85 8.4 17.62 8.22Z" fill="url(#paint1_radial_4575_347)" fill-opacity="0.5"/>
<path d="M18 9C18 9.32 17.85 9.6 17.62 9.78L13.16 13.35L12.14 14.17C12.73 13.7 12.88 12.87 12.5 12.23L10.58 9L6.14 1.51C6.05 1.36 6 1.19 6 1C6 0.45 6.45 0 7 0C7.24 0 7.45 0.08 7.62 0.22L17.62 8.22C17.85 8.4 18 8.68 18 9Z" fill="url(#paint2_linear_4575_347)"/>
<path d="M3.625 16C3.98496 16 4.30512 16.19 4.48511 16.49C4.72506 16.88 4.66492 17.38 4.34497 17.7C4.145 17.8999 3.89495 18 3.625 18H1.00002C0.830074 18 0.659995 17.9601 0.510033 17.8701C0.110033 17.6401 -0.0799476 17.18 0.0300524 16.74C0.150055 16.31 0.550058 16 1.00002 16H3.625Z" fill="url(#paint3_linear_4575_347)"/>
<path d="M5.25 12C5.58997 12 5.92012 12.18 6.11011 12.49C6.29007 12.8 6.29007 13.2 6.11011 13.51C5.92012 13.82 5.58997 14 5.25 14H1.00002C0.910076 14 0.819973 13.9899 0.740013 13.96C0.300059 13.8499 2.31351e-05 13.45 2.31351e-05 13C2.31351e-05 12.55 0.300059 12.1501 0.740013 12.04C0.819973 12.0101 0.910076 12 1.00002 12H5.25Z" fill="url(#paint4_linear_4575_347)"/>
<path d="M2.01003 8C2.34998 8.00003 2.67991 8.18005 2.8699 8.48999C3.0499 8.79999 3.0499 9.20001 2.8699 9.51001C2.67991 9.81995 2.34998 9.99997 2.01003 10H1.00002C0.910061 10 0.819984 9.98994 0.740013 9.95996C0.300043 9.84994 2.31351e-05 9.44998 2.31351e-05 9C2.31351e-05 8.55002 0.300043 8.15006 0.740013 8.04004C0.819984 8.01006 0.910061 8 1.00002 8H2.01003Z" fill="url(#paint5_linear_4575_347)"/>
<path d="M7.63992 8C7.97991 8 8.31002 8.18001 8.50002 8.48999C8.68 8.79998 8.68 9.20002 8.50002 9.51001C8.31002 9.81999 7.97991 10 7.63992 10H5.00002C4.91006 10 4.81998 9.98994 4.74001 9.95996C4.30004 9.84994 4.00002 9.44998 4.00002 9C4.00002 8.55002 4.30004 8.15006 4.74001 8.04004C4.81998 8.01006 4.91006 8 5.00002 8H7.63992Z" fill="url(#paint6_linear_4575_347)"/>
</g>
<defs>
<linearGradient id="paint0_linear_4575_347" x1="11.5687" y1="5.79567" x2="4.90825" y2="18.8817" gradientUnits="userSpaceOnUse">
<stop stop-color="#8B52F4"/>
<stop offset="0.52" stop-color="#7A41DC"/>
<stop offset="0.97" stop-color="#9529C1"/>
</linearGradient>
<radialGradient id="paint1_radial_4575_347" cx="0" cy="0" r="1" gradientUnits="userSpaceOnUse" gradientTransform="translate(8 14.25) rotate(-18.1381) scale(7.6291 11.4609)">
<stop offset="0.307474" stop-color="#7D45E2" stop-opacity="0"/>
<stop offset="0.574002" stop-color="#3B148A"/>
</radialGradient>
<linearGradient id="paint2_linear_4575_347" x1="6.25" y1="-1.25" x2="17.5" y2="12.25" gradientUnits="userSpaceOnUse">
<stop stop-color="#3BD5FF"/>
<stop offset="0.502883" stop-color="#367AF2"/>
<stop offset="0.949445" stop-color="#9C6CFE"/>
</linearGradient>
<linearGradient id="paint3_linear_4575_347" x1="7.49994" y1="8.875" x2="-4.37506" y2="18" gradientUnits="userSpaceOnUse">
<stop offset="0.0244608" stop-color="#367AF2"/>
<stop offset="0.472842" stop-color="#7A41DC"/>
<stop offset="0.804936" stop-color="#9529C1"/>
</linearGradient>
<linearGradient id="paint4_linear_4575_347" x1="7.49994" y1="8.875" x2="-4.37506" y2="18" gradientUnits="userSpaceOnUse">
<stop offset="0.0244608" stop-color="#367AF2"/>
<stop offset="0.472842" stop-color="#7A41DC"/>
<stop offset="0.804936" stop-color="#9529C1"/>
</linearGradient>
<linearGradient id="paint5_linear_4575_347" x1="7.49994" y1="8.875" x2="-4.37506" y2="18" gradientUnits="userSpaceOnUse">
<stop offset="0.0244608" stop-color="#367AF2"/>
<stop offset="0.472842" stop-color="#7A41DC"/>
<stop offset="0.804936" stop-color="#9529C1"/>
</linearGradient>
<linearGradient id="paint6_linear_4575_347" x1="7.49994" y1="8.875" x2="-4.37506" y2="18" gradientUnits="userSpaceOnUse">
<stop offset="0.0244608" stop-color="#367AF2"/>
<stop offset="0.472842" stop-color="#7A41DC"/>
<stop offset="0.804936" stop-color="#9529C1"/>
</linearGradient>
<clipPath id="clip0_4575_347">
<rect width="18" height="18" fill="white"/>
</clipPath>
</defs>
</svg>App Service<br> Builder</span></div>
      <nav aria-label="On this page">
        <a href="#overview"><span class="nav-symbol" aria-hidden="true">&#9638;</span>Overview</a>
        <a href="#endpoints"><span class="nav-symbol" aria-hidden="true">&#8644;</span>HTTP endpoints</a>
        <a href="#next-steps"><span class="nav-symbol" aria-hidden="true">&#8599;</span>Next steps</a>
      </nav>
      <div class="rail-foot"><strong>Small by design.</strong>A standalone ASP.NET sample.<br>No package dependencies.</div>
    </aside>
    <main class="workspace" id="main">
      <header class="topbar">
        <div class="breadcrumb"><span>Samples</span><span aria-hidden="true">/</span><strong>dotnet-web</strong></div>
      </header>
      <section id="overview" aria-labelledby="page-title">
        <div class="intro">
          <div><h1 id="page-title">Your .NET workbench</h1><p>A minimal app. A real HTTP response. A place to start.</p></div>
          <div class="runtime"><span>.NET</span>10 / ASP.NET</div>
        </div>
        <div class="overview">
          <div class="greeting">
            <div class="response-label"><span>Public greeting</span><code>GET /</code></div>
            <h2>{{GREETING}}</h2>
            <p>App Service Builder / dotnet-web</p>
            <p class="public-note">Rendered from SAMPLE_GREETING. Defaults to Hello.</p>
          </div>
          <div class="facts">
            <h2>The app at a glance</h2>
            <dl>
              <div class="fact"><dt>Runtime</dt><dd>.NET 10</dd></div>
              <div class="fact"><dt>Component</dt><dd>web</dd></div>
              <div class="fact"><dt>Listening port</dt><dd><code>8080</code></dd></div>
              <div class="fact"><dt>Health check</dt><dd><code>/health</code></dd></div>
            </dl>
          </div>
        </div>
      </section>
      <section id="endpoints" aria-labelledby="endpoints-title">
        <div class="section-heading"><h2 id="endpoints-title">Try a request</h2><p>Calls this app. No credentials required.</p></div>
        <div class="endpoints">
          <div class="endpoint">
            <span class="method">GET</span><a class="path" href="/"><code>/</code></a><p>This HTML workbench and public greeting.</p>
            <button type="button" data-path="/" aria-label="Run GET /">Run <span aria-hidden="true">&#8599;</span></button>
          </div>
          <div class="endpoint">
            <span class="method">GET</span><a class="path" href="/health"><code>/health</code></a><p>A simple health-check response.</p>
            <button type="button" data-path="/health" aria-label="Run GET /health">Run <span aria-hidden="true">&#8599;</span></button>
          </div>
        </div>
        <div class="result" id="result" hidden role="status" aria-live="polite" aria-atomic="true">
          <div class="result-heading" id="result-heading"></div><pre id="result-body"></pre>
        </div>
        <noscript><p>JavaScript is off. Open the endpoint links above to view their responses.</p></noscript>
      </section>
      <section class="next" id="next-steps" aria-labelledby="next-title">
        <div><h2 id="next-title">Make the greeting yours.</h2><p>Set <code>SAMPLE_GREETING</code>, then restart locally or explicitly deploy to apply it. Its value is public: never use a secret.</p></div>
        <a href="https://builder.appservice.azure.com/docs/guides/variables/">Variables guide <span aria-hidden="true">&#8599;</span></a>
      </section>
      <footer><span>App Service Builder &middot; Development and testing only.</span><span>Local responses do not verify deployment readiness.</span></footer>
    </main>
  </div>
  <script>
    const buttons = document.querySelectorAll('button[data-path]');
    const result = document.getElementById('result');
    const heading = document.getElementById('result-heading');
    const body = document.getElementById('result-body');
    for (const button of buttons) {
      button.addEventListener('click', async () => {
        const path = button.dataset.path;
        for (const control of buttons) control.disabled = true;
        result.hidden = false;
        result.dataset.error = 'false';
        heading.textContent = `GET ${path} - Requesting...`;
        body.textContent = '';
        try {
          const response = await fetch(path, { cache: 'no-store', signal: AbortSignal.timeout(10000) });
          const text = await response.text();
          result.dataset.error = String(!response.ok);
          const contentType = response.headers.get('content-type') || 'Unknown content type';
          heading.textContent = `GET ${path} - HTTP ${response.status} - ${contentType}`;
          if (!response.ok) {
            body.textContent = `The endpoint returned an error.\n${text || 'No response body.'}`;
          } else if (path === '/' && contentType.startsWith('text/html')) {
            const page = new DOMParser().parseFromString(text, 'text/html');
            const greeting = page.querySelector('.greeting h2');
            body.textContent = greeting
              ? `${page.title}\nPublic greeting: ${greeting.textContent}`
              : 'Received HTML, but the public greeting was not found.';
          } else {
            body.textContent = text;
          }
        } catch (error) {
          result.dataset.error = 'true';
          heading.textContent = `GET ${path} - Request failed`;
          body.textContent = error.name === 'TimeoutError'
            ? 'The request timed out. Check that the app is running and try again.'
            : 'Could not reach the endpoint. Check your connection and try again.';
        } finally {
          for (const control of buttons) control.disabled = false;
        }
      });
    }
  </script>
</body>
</html>
""";
}
