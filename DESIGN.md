---
name: .NET workbench
description: Plum-and-neutral developer workbench for the ASP.NET sample.
colors:
  ink: "#29252e"
  muted: "#65606c"
  plum: "#633d71"
  plum-deep: "#39283f"
  canvas: "#f5f4f7"
  line: "#dedbe3"
  white: "#fff"
  soft: "#ede8f1"
typography:
  display:
    fontFamily: '-apple-system, BlinkMacSystemFont, "Segoe UI", sans-serif'
    fontSize: "64px"
    fontWeight: 550
    lineHeight: 1.12
    letterSpacing: "-.035em"
  headline:
    fontFamily: '-apple-system, BlinkMacSystemFont, "Segoe UI", sans-serif'
    fontSize: "32px"
    fontWeight: 650
    lineHeight: 1.2
    letterSpacing: "-.035em"
  body:
    fontFamily: '-apple-system, BlinkMacSystemFont, "Segoe UI", sans-serif'
    fontSize: "15px"
    lineHeight: 1.6
  code:
    fontFamily: "ui-monospace, SFMono-Regular, Consolas, monospace"
    fontSize: "13px"
rounded:
  badge: "4px"
  button: "5px"
  navigation: "6px"
  result: "7px"
  endpoints: "8px"
  overview: "10px"
components:
  request-button:
    backgroundColor: "{colors.white}"
    textColor: "{colors.plum}"
    rounded: "{rounded.button}"
    padding: "8px 14px"
  request-button-hover:
    backgroundColor: "{colors.soft}"
  overview:
    backgroundColor: "{colors.white}"
    rounded: "{rounded.overview}"
  greeting:
    backgroundColor: "{colors.plum}"
    textColor: "{colors.white}"
    padding: "26px 32px 28px"
---

# Design System: .NET workbench

## Overview

**Creative North Star: "Plum-and-neutral developer workbench"**

This records the implemented `/` system in `DemoPage.cs`, not a broader
component library. System typography, flat mineral surfaces, plum navigation,
and monospaced HTTP details give the small sample a structured developer-tool
identity.

**Key Characteristics:**
- Plum navigation and greeting field against a pale neutral canvas.
- Compact, ruled facts and endpoint rows.
- System sans-serif headings with monospace request details.

## Colors

### Primary
- **Plum:** greeting field, links, and request-control text.
- **Deep plum:** navigation background.
- **Soft plum:** request-control hover surface.

### Neutral
- **Ink:** headings and primary content.
- **Muted:** descriptions, labels, and footer text.
- **Canvas:** workspace background.
- **White:** facts and endpoint surfaces.
- **Line:** container borders and section dividers.

Additional state-specific colors remain local CSS values: focus violet
(`#aa5bcc`), error border (`#a64b51`), error surface (`#fff1f1`), and error text
(`#8a2931`).

## Typography

The display, headline, and body roles share the system sans-serif stack.
The greeting uses the display role; the page title uses headline. Section
headings are (20px), secondary headings (16px), and supporting text primarily
(12–13px). Copy in the introduction and next-step guidance is limited to (65ch).
Paths, methods, port values, and returned bodies use system monospace.

At the mobile breakpoint, the greeting drops to (56px), the page title to
(28px), and introductory copy to (14px). Greeting and result text wrap anywhere
to accommodate long public values.

## Layout

Desktop uses a (230px) rail beside a flexible workspace, with workspace padding
of (52px) and a maximum workspace width of (1510px). The overview places a
greeting and facts side by side in a (1.8:1) grid; endpoint rows align method,
path, description, and action.

At widths up to (1100px), the rail becomes (190px), workspace padding becomes
(30px), and the overview ratio narrows. At widths up to (760px), the rail
becomes a top navigation band, workspace padding becomes (22px), and the
overview stacks. Endpoint descriptions move beneath paths, while Run controls
remain at the right. Navigation symbols and rail footnote are hidden on mobile.
At widths from (1600px), workspace padding increases to (70px).

## Elevation & Depth

There are no shadows. Depth comes from the deep navigation band, saturated
greeting field, white content surfaces, pale canvas, and thin borders.

## Shapes

Rectangular surfaces have modest corner rounding. The overview clips its
greeting and facts into one shared container. Endpoint rows share an outlined
container and internal dividers. Small method badges and code labels use
tighter rounding than content containers; there are no pill-shaped controls.

## Components

### Navigation

The desktop rail uses light text, a filled Overview anchor, and a lighter plum
hover fill. These are same-page anchors; the Overview fill is static, not a
scroll-position indicator. Mobile navigation wraps horizontally.

### Greeting and facts

The large greeting field pairs a small response label and outlined request
badge with display-sized content. Facts use a definition list with thin rules,
muted labels, and right-aligned values.

### Request controls

White outlined buttons use plum text, a minimum height of (40px), and a
(150ms ease-out) background/border transition. Hover uses soft plum; active
uses a deeper pale plum. While requesting, both controls are disabled and
show a wait cursor.

### Method badges and results

GET badges are compact, pale-plum monospace labels. The shared result surface
is hidden initially, then shows request status and a wrapping monospace body.
Errors switch to the local red border, surface, and text treatment.
The root request summarizes the fetched HTML title and public greeting as text;
the health request shows its plain-text body. Both display HTTP status and
content type. Returned HTML is never inserted as active page content.

### Focus and motion

Focus-visible uses a (3px) violet outline with (5px) offset. A skip link appears
on focus. Anchor scrolling is smooth; reduced-motion preference disables smooth
scrolling and button transitions.

## Do's and Don'ts

### Do:
- **Do** retain system typography and monospace HTTP details.
- **Do** use flat tonal surfaces and thin dividers rather than shadows.
- **Do** preserve wrapping for variable greeting and response content.

### Don't:
- **Don't** replace the approved plum-and-neutral identity with another palette.
- **Don't** introduce decorative charts or telemetry widgets into this small workbench.
