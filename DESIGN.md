---
name: .NET workbench
description: Daylight-blue and lavender developer workbench for the ASP.NET sample.
colors:
  ink: "#23314c"
  muted: "#5d6d87"
  accent: "#6250d1"
  canvas: "#eff3fc"
  line: "#e4e8f2"
  white: "#fff"
  soft: "#f1effb"
typography:
  display:
    fontFamily: '"Segoe UI Variable", "Segoe UI", Arial, sans-serif'
    fontSize: "68px"
    fontWeight: 650
    lineHeight: 1.1
    letterSpacing: "-.04em"
  headline:
    fontFamily: '"Segoe UI Variable", "Segoe UI", Arial, sans-serif'
    fontSize: "30px"
    fontWeight: 650
    lineHeight: 1.08
    letterSpacing: "-.04em"
  body:
    fontFamily: '"Segoe UI Variable", "Segoe UI", Arial, sans-serif'
    fontSize: "15px"
    lineHeight: 1.7
  code:
    fontFamily: "Consolas, monospace"
    fontSize: "12px"
rounded:
  button: "9px"
  navigation: "9px"
  result: "14px"
  endpoints: "14px"
  overview: "17px"
  shell: "24px"
components:
  request-button:
    backgroundColor: "{colors.white}"
    textColor: "{colors.accent}"
    rounded: "{rounded.button}"
    padding: "9px 14px"
  overview:
    backgroundColor: "{colors.white}"
    rounded: "{rounded.overview}"
  greeting:
    backgroundColor: "#f5f2fd"
    textColor: "#493777"
    padding: "25px 29px"
---

# Design System: .NET workbench

## Overview

The implemented `/` page in `DemoPage.cs` belongs to the approved soft daylight
sample family while retaining its structured .NET request-workbench layout.
A blue/lavender canvas surrounds an elevated white shell. A pale navigation
rail, lavender greeting field, ruled facts, and monospaced HTTP details keep
the content distinct from a centered hello-world sample.

Official .NET and App Service Builder artwork is local and inlined. Sources
and trademark notices are in [assets/NOTICE.md](assets/NOTICE.md). ASP.NET
and Builder documentation are explicitly separate navigation links.

## Layout and depth

Desktop uses a 210px rail inside a 1230px maximum-width shell, with 35px
workspace padding. Greeting and facts share a rounded 1.55:1 overview. Endpoint
rows align method, path, description, and action. The white shell uses a soft
shadow; inner surfaces use thin borders and restrained tonal gradients.

At 900px, the rail narrows to 175px, workspace padding becomes 25px, and the
overview stacks. At 600px, the rail becomes a top navigation band, workspace
padding becomes 21px, and endpoint descriptions move beneath their paths.
The 19px mobile shell keeps the request controls at the right. Navigation
symbols and the rail footnote are hidden on mobile.

## Typography and shapes

System sans-serif type carries the hierarchy through size, weight and spacing.
The greeting is 68px, the page title 30px, and section headings 18px. Supporting
text is primarily 11–13px. HTTP paths and response bodies use Consolas.
Mobile greeting and page-title sizes are 58px and 26px. Variable greeting and
response content wraps anywhere rather than overflowing.

Surfaces use 14–24px corner rounding; outlined request controls use 9px rounding
and a minimum 40px height. Method labels are noninteractive, lavender-backed
monospace badges. Navigation anchors do not imply selected or telemetry state.

## Request controls and customization

Both controls call existing local endpoints and are disabled while a request
is pending. The initially hidden, live result surface displays real status,
content type, and a wrapping text body. Root requests summarize the fetched
HTML title and public greeting without executing or inserting returned HTML.
Health requests display the exact text body inline; they do not navigate or
download it. Errors stay visible and the same control can retry.

The customization disclosure names `SAMPLE_GREETING` and its source files,
explains public-value and redeployment behavior, and does not infer a user's
fork or edit deployment settings. Local responses do not verify Azure readiness.

## Accessibility and motion

Focus-visible uses a 3px violet outline with 4px offset. A skip link appears
on focus; buttons and disclosures are keyboard-operable. Error wording and
visible results communicate state independently of color. Reduced-motion
users receive no control animation or smooth-scroll requirement.

Retain factual content, official artwork, variable-value wrapping and real
responses. Additional charts, monitoring state, or simulated success do not
belong in this sample.
