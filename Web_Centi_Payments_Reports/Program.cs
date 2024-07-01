using Web_Centi_Payments_Reports.Components;
using Web_Centi_Payments_Reports.Components.Identity;
using Web_Centi_Payments_Reports.Components.Services;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using CurrieTechnologies.Razor.SweetAlert2;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ICodeudorService, CodeudorService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPdfService, PdfService>();

builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
builder.Services.AddHttpClient<IClienteService, ClienteService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7150/api/v1/CentinelaCobroEnLinea/ReporteCentinela");
});

builder.Services.AddHttpClient<ICodeudorService, CodeudorService>(codeudor =>
{
    codeudor.BaseAddress = new Uri("https://localhost:7150/api/v1/CentinelaCobroEnLinea/ReporteCentinelaCodeudor");
});
builder.Services.AddSweetAlert2();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:7150") });

//builder.Services.AddHttpClient<IAuthService, AuthService>(login =>
//{
//    login.BaseAddress = new Uri("https://devxtr12/ApiSegurinetAuthentication/api/v1/SegClient/SegNetClient/Login");
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.Run();