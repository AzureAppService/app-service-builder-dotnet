var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://0.0.0.0:8080");
var app = builder.Build();

app.MapGet("/health", () => Results.Text("OK\n"));
app.MapGet("/", () =>
{
    var greeting = Environment.GetEnvironmentVariable("SAMPLE_GREETING");
    return Results.Content(DemoPage.Render(string.IsNullOrEmpty(greeting) ? "Hello" : greeting), "text/html; charset=utf-8");
});

app.Run();
