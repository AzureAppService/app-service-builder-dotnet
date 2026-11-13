using System.Text.Encodings.Web;

internal static class DemoPage
{
    internal static string Render(string greeting) =>
        Page.Replace("{{GREETING}}", HtmlEncoder.Default.Encode(greeting), StringComparison.Ordinal);

    private const string Page = """
<!doctype html>
<html lang="en">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <meta name="theme-color" content="#eff3fc">
  <meta name="description" content="Explore the public greeting and HTTP endpoints of the App Service Builder ASP.NET sample.">
  <link rel="icon" href="data:,">
  <title>.NET workbench | App Service Builder</title>
  <style>
    :root { color-scheme: light; --ink:#23314c; --muted:#5d6d87; --line:#e4e8f2; --accent:#6250d1; --soft:#f1effb; }
    * { box-sizing:border-box; }
    body { margin:0; min-height:100vh; color:var(--ink); font:15px/1.7 "Segoe UI Variable","Segoe UI",Arial,sans-serif; background:radial-gradient(ellipse at 0 10%,#dceaff,transparent 60%),radial-gradient(ellipse at 100% 85%,#e8e0fa,transparent 60%),#eff3fc; }
    a { color:inherit; text-underline-offset:4px; }
    a:hover { color:var(--accent); }
    a:focus-visible,button:focus-visible,summary:focus-visible { outline:3px solid #7660d0; outline-offset:4px; }
    button,a,summary { touch-action:manipulation; }
    button { font:inherit; cursor:pointer; }
    button:disabled { opacity:.6; cursor:wait; }
    [hidden] { display:none!important; }
    .skip,.skip-link { position:absolute; top:-90px; left:20px; background:#fff; padding:12px; z-index:3; }
    .skip:focus,.skip-link:focus { top:10px; }
    .brand { display:flex; align-items:center; gap:11px; font-size:17px; font-weight:650; letter-spacing:-.02em; text-decoration:none; }
    .brand-logo { display:block; width:30px; height:30px; flex:none; }
    .ecosystem-logo { display:block; width:64px; height:64px; flex:none; }
    nav { display:flex; align-items:center; gap:22px; font-size:12px; color:#546581; }
    nav a { text-decoration:none; }
    nav a:hover { text-decoration:underline; }
    h1,h2 { text-wrap:balance; }
    h1 { letter-spacing:-.04em; line-height:1.08; font-weight:650; }
    h2 { letter-spacing:-.02em; line-height:1.35; }
    code,pre { font-family:Consolas,monospace; overflow-wrap:anywhere; }
    pre { white-space:pre-wrap; margin:0; font-size:12px; line-height:1.8; }
    details { font-size:12px; color:var(--muted); line-height:1.8; }
    summary { cursor:pointer; color:#435676; font-weight:600; }
    details p { max-width:76ch; }
    footer { display:flex; justify-content:space-between; gap:22px; color:var(--muted); font-size:11px; line-height:1.8; }
    .brand-notices { margin:0; padding:18px 0 0; border-top:1px solid var(--line); }
    .brand-notices summary { font-size:10px; font-weight:400; }
    .brand-notices p { font-size:10px; }
    .button,.primary { display:inline-flex; align-items:center; justify-content:center; gap:14px; min-height:44px; padding:12px 20px; border:0; border-radius:10px; background:var(--accent); color:#fff; font-size:13px; font-weight:600; text-decoration:none; box-shadow:0 5px 12px #47369c1a; }
    .button:hover,.primary:hover { background:#5140b6; color:#fff; }
    #health-status { font-size:11px; line-height:1.8; min-height:36px; color:var(--muted); overflow-wrap:anywhere; }
    @media(max-width:600px) {
      .brand { font-size:16px; }
      nav { width:100%; justify-content:space-between; flex-wrap:wrap; gap:10px 14px; font-size:11px; }
      footer { flex-direction:column; gap:6px; }
    }
    @media(prefers-reduced-motion:no-preference) { .button,.primary { transition:background .15s ease-out; } }

    .shell { display:grid; grid-template-columns:210px minmax(0,1fr); max-width:1230px; margin:32px auto; background:#fff; border-radius:24px; overflow:hidden; box-shadow:0 22px 65px #3b487515; }
    .rail { background:linear-gradient(155deg,#f2f0fd,#edf4ff); padding:32px 22px; border-right:1px solid var(--line); display:flex; flex-direction:column; }
    .rail .brand { align-items:flex-start; font-size:14px; gap:9px; }
    .rail .brand-logo { width:26px; height:26px; }
    .rail nav { display:grid; gap:8px; margin-top:42px; }
    .rail nav a { display:flex; gap:12px; padding:10px 12px; border-radius:9px; color:#536280; }
    .rail nav a:hover { background:#e4e0f6; }
    .nav-symbol { font-size:17px; }
    .rail-foot { margin-top:auto; padding-top:60px; font-size:11px; color:var(--muted); }
    .rail-foot strong { display:block; color:#435676; }
    .workspace { min-width:0; padding:0 35px 26px; }
    .topbar { min-height:90px; border-bottom:1px solid var(--line); display:flex; flex-wrap:wrap; justify-content:space-between; align-items:center; gap:15px; }
    .breadcrumb { display:flex; gap:10px; font-size:11px; color:var(--muted); }
    .intro { display:flex; align-items:center; justify-content:space-between; gap:25px; margin:30px 0 25px; }
    h1 { margin:0 0 9px; font-size:30px; }
    .intro p { margin:0; color:var(--muted); font-size:13px; }
    .runtime { display:flex; align-items:center; gap:12px; font-size:12px; font-weight:600; }
    .runtime svg { width:48px; height:48px; }
    .overview { display:grid; grid-template-columns:minmax(0,1.55fr) minmax(220px,1fr); border:1px solid var(--line); border-radius:17px; overflow:hidden; }
    .greeting { padding:25px 29px; min-height:255px; background:radial-gradient(ellipse at 0 90%,#e5eefd,transparent 75%),#f5f2fd; display:flex; flex-direction:column; align-items:flex-start; }
    .response-label { display:flex; justify-content:space-between; gap:14px; width:100%; font-size:11px; color:#625291; }
    .greeting h2 { margin:26px 0 22px; font-size:68px; font-weight:650; line-height:1.1; color:#493777; max-width:100%; overflow-wrap:anywhere; }
    .greeting p { margin:auto 0 0; font-size:12px; color:#5c6d89; }
    .greeting .public-note { font-size:10px; margin-top:6px; }
    .facts { padding:25px; }
    .facts h2 { font-size:15px; margin:0 0 14px; }
    dl { margin:0; }
    .fact { display:flex; justify-content:space-between; gap:15px; padding:11px 0; border-top:1px solid var(--line); font-size:12px; }
    dt { color:var(--muted); } dd { margin:0; font-weight:600; }
    .section-heading { display:flex; justify-content:space-between; align-items:baseline; gap:18px; margin:27px 0 14px; }
    .section-heading h2 { font-size:18px; margin:0; }
    .section-heading p { font-size:11px; color:var(--muted); margin:0; }
    .endpoints { border:1px solid var(--line); border-radius:14px; overflow:hidden; }
    .endpoint { display:grid; grid-template-columns:48px minmax(85px,1fr) minmax(100px,1.3fr) auto; gap:14px; padding:18px 20px; align-items:center; }
    .endpoint + .endpoint { border-top:1px solid var(--line); }
    .method { background:#eeebfc; color:#6252bd; border-radius:7px; padding:3px 7px; text-align:center; font:600 11px/1.7 Consolas,monospace; }
    .path { font-size:12px; font-weight:600; }
    .endpoint p { margin:0; color:var(--muted); font-size:11px; }
    button { border:1px solid #d2c9ed; background:#fff; color:#5947b7; border-radius:9px; min-height:40px; padding:9px 14px; font-size:12px; font-weight:600; }
    button:hover { background:var(--soft); }
    .result { margin-top:14px; padding:17px 20px; border:1px solid #dce3f1; border-radius:14px; background:linear-gradient(145deg,#f1f5fe,#f1edf9); }
    .result-heading { font-size:12px; font-weight:600; }
    .result pre { margin-top:10px; }
    .result[data-error="true"] { border-color:#ac5a62; background:#fff1f1; color:#8a2931; }
    .next { margin-top:23px; padding:21px 0; border-block:1px solid var(--line); }
    .next h2 { font-size:15px; margin:0 0 12px; }
    .next p { margin:12px 0; }
    .next a { font-size:12px; }
    footer { padding:20px 0; }
    @media(max-width:1280px) { .shell { margin:25px 20px; } }
    @media(max-width:900px) {
      .shell { grid-template-columns:175px minmax(0,1fr); }
      .rail { padding:26px 16px; }
      .workspace { padding-inline:25px; }
      .overview { grid-template-columns:1fr; }
      .intro { align-items:flex-start; }
      .runtime { flex-direction:column; gap:7px; text-align:center; }
    }
    @media(max-width:600px) {
      .shell { display:block; margin:18px 15px; border-radius:19px; }
      .rail { padding:23px 21px; border-right:0; border-bottom:1px solid var(--line); }
      .rail .brand { align-items:center; font-size:16px; }
      .brand br { display:none; }
      .rail nav { display:flex; justify-content:space-between; gap:5px; margin-top:17px; font-size:10px; }
      .rail nav a { padding:4px 0; }
      .nav-symbol,.rail-foot { display:none; }
      .workspace { padding:0 21px 22px; }
      .topbar { padding:18px 0; min-height:0; }
      .intro { gap:15px; margin:25px 0; }
      h1 { font-size:26px; }
      .intro p { font-size:12px; }
      .runtime { font-size:10px; flex:none; }
      .runtime svg { width:40px; height:40px; }
      .greeting { padding:22px; }
      .greeting h2 { font-size:58px; }
      .facts { padding:22px; }
      .section-heading { flex-direction:column; gap:5px; }
      .endpoint { grid-template-columns:40px minmax(0,1fr) auto; gap:10px; padding:16px; }
      .endpoint p { grid-column:2; grid-row:2; }
      .endpoint button { grid-column:3; grid-row:1/3; }
    }
</style>
</head>
<body>
  <a class="skip" href="#main">Skip to content</a>
  <div class="shell">
    <aside class="rail" aria-label="Sample navigation">
      <div class="brand"><svg class="brand-logo" role="img" aria-label="App Service Builder" width="18" height="18" viewBox="0 0 18 18" fill="none" xmlns="http://www.w3.org/2000/svg">
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
</svg><span>App Service<br> Builder</span></div>
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
      <nav aria-label="Documentation"><a href="https://learn.microsoft.com/aspnet/core/">ASP.NET documentation ↗</a><a href="https://builder.appservice.azure.com/docs/">Builder documentation ↗</a></nav></header>
      <section id="overview" aria-labelledby="page-title">
        <div class="intro">
          <div><h1 id="page-title">Your .NET workbench</h1><p>A minimal app. A real HTTP response. A place to start.</p></div>
          <div class="runtime"><svg class="ecosystem-logo" role="img" aria-label=".NET" width="456" height="456" viewBox="0 0 456 456" fill="none" xmlns="http://www.w3.org/2000/svg">
<rect width="456" height="456" fill="#512BD4"/>
<path d="M81.2738 291.333C78.0496 291.333 75.309 290.259 73.052 288.11C70.795 285.906 69.6665 283.289 69.6665 280.259C69.6665 277.173 70.795 274.529 73.052 272.325C75.309 270.121 78.0496 269.019 81.2738 269.019C84.5518 269.019 87.3193 270.121 89.5763 272.325C91.887 274.529 93.0424 277.173 93.0424 280.259C93.0424 283.289 91.887 285.906 89.5763 288.11C87.3193 290.259 84.5518 291.333 81.2738 291.333Z" fill="white"/>
<path d="M210.167 289.515H189.209L133.994 202.406C132.597 200.202 131.441 197.915 130.528 195.546H130.044C130.474 198.081 130.689 203.508 130.689 211.827V289.515H112.149V171H134.477L187.839 256.043C190.096 259.57 191.547 261.994 192.192 263.316H192.514C191.977 260.176 191.708 254.859 191.708 247.365V171H210.167V289.515Z" fill="white"/>
<path d="M300.449 289.515H235.561V171H297.87V187.695H254.746V221.249H294.485V237.861H254.746V272.903H300.449V289.515Z" fill="white"/>
<path d="M392.667 187.695H359.457V289.515H340.272V187.695H307.143V171H392.667V187.695Z" fill="white"/>
</svg><span>.NET 10<br>ASP.NET</span></div>
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
            <span class="method">GET</span><span class="path"><code>/health</code></span><p>Liveness only. Not Azure readiness.</p>
            <button type="button" data-path="/health" aria-label="Check app health">Check health <span aria-hidden="true">&#8599;</span></button>
          </div>
        </div>
        <div class="result" id="result" hidden role="status" aria-live="polite" aria-atomic="true">
          <div class="result-heading" id="result-heading"></div><pre id="result-body"></pre>
        </div>
        <noscript><p>JavaScript is off. Open <code>/health</code> in your browser or use curl to inspect its response.</p></noscript>
      </section>
      <section class="next" id="next-steps" aria-labelledby="next-title">
        <h2 id="next-title">Make the greeting yours.</h2>
        <details id="customize"><summary>Customize the public greeting</summary><p><code>Program.cs</code> reads <code>SAMPLE_GREETING</code> and <code>DemoPage.cs</code> renders it as escaped text. Set it before restarting locally or save and deploy a new version in your Builder App. The default is <code>Hello</code>. Never use a secret: this greeting is public. This page does not change source or deployment settings.</p><a href="https://builder.appservice.azure.com/docs/guides/variables/">Builder variables guide ↗</a></details>
      </section>
      <footer><span>App Service Builder &middot; Development and testing only.</span><span>Local responses do not verify deployment readiness.</span></footer>
      <details class="brand-notices"><summary>Official logos &amp; trademark notices</summary><p><a href="https://github.com/dotnet/brand">.NET brand source</a>. Logos identify their respective ecosystems; trademarks belong to their owners. The supplied App Service Builder mark identifies the hosting platform, not ecosystem endorsement. Local copies and provenance are in <code>assets/</code>.</p></details>
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
