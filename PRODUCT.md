# Product

<!-- impeccable:product-schema 1 -->

## Platform

web

## Users and purpose

Developers evaluating a minimal ASP.NET sample for App Service Builder. The
`/` showcase also supplies a recognizable visual for template thumbnails.

## Capabilities and constraints

The app uses .NET 10 without NuGet dependencies. `/` returns the HTML workbench
with a public, HTML-encoded greeting, `/health` returns `OK`, and unknown routes
return 404. The app binds port 8080. Preserve these contracts, `builder.yaml`, and
the deployment workflow.
`SAMPLE_GREETING` is public and must never contain a secret.

The approved `/` page presents the actual greeting and existing runtime
facts. User-triggered request controls call only `/` and `/health` and display
real responses or errors. Root requests summarize the returned HTML title and
greeting as text; health requests display the plain-text body. There is no
deployment telemetry or account backend.

## Brand commitments

The approved direction is a distinct, structured .NET workbench in the shared
daylight-blue/lavender sample family: an elevated white rounded shell, pale
navigation, official .NET and Builder marks, and a lavender public-greeting
surface. Preserve factual sample content, responsive layouts, accessible
contrast, and keyboard-operable controls. ASP.NET documentation is separate
from Builder documentation. Customization discloses the source variable name
without inferring a fork or modifying deployment settings.

## Evidence on hand

`Program.cs`, `builder.yaml`, and `README.md` establish the runtime and endpoint
behavior. Private Preview is for development and testing; local success does
not prove live deployment readiness.
