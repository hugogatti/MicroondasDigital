using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MicroondasDigital.Business.Interfaces;
using MicroondasDigital.Business.Services;
using MicroondasDigital.Web;

var builder = WebApplication.CreateBuilder(args);

// Adicionando o servi�o do micro-ondas
builder.Services.AddScoped<IMicroondasService, MicroondasService>();

// Configura��es padr�o do Blazor
//builder.Services.AddRazorComponents()
//    .AddInteractiveComponents();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Configura��o do pipeline de requisi��o
app.UseRouting();
//app.MapBlazorComponents<App>()
//   .AddInteractiveComponents();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
