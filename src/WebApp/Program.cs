using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
}

app.UseStaticFiles();

app.MapGet("/", async context =>
{
    await context.Response.SendFileAsync("wwwroot/index.html");
});

app.MapPost("/api/download", async context =>
{
    // TODO: integrate download logic using Playwright
    var url = context.Request.Form["url"].ToString();
    if (string.IsNullOrWhiteSpace(url))
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Missing url");
        return;
    }
    // Placeholder response
    await context.Response.WriteAsync($"Download requested for {url}. (Not yet implemented)");
});

app.Run();
