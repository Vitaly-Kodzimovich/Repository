var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

void Fun(IApplicationBuilder appBuilder)
{
    appBuilder.Run(async context => await context.Response.WriteAsync("Fun"));
}
app.Map("/Fun", Fun);

async Task Main(HttpContext context)
{
    var response = context.Response;
    response.ContentType = "text/html; charset=utf-8";
    await response.SendFileAsync("html/index.html");
}

app.Run(Main);
app.Run();
