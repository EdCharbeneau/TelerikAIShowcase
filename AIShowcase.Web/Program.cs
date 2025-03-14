using AIShowcase.WebApp;
using AIShowcase.WebApp.Components;
using System.Globalization;
using CommunityToolkit.Aspire.OllamaSharp;
using AIShowcase.WebApp.Components.ChatOutputServices;
using AIShowcase.WebApp.Support;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

builder.Services.AddSpeechRecognitionServices();

// If local uncomment this line
//builder.AddOllamaApiClient("connectionName").AddChatClient();

builder.AddChatServices();
builder.Services.AddScoped<MenuVectorData>();
builder.Services.AddSpeechServices();
builder.Services.AddTelerikBlazor();
builder.Services.AddScoped<PrismInterop>();

// Register HttpClient
builder.Services.AddHttpClient();

var culture = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

var app = builder.Build();

app.MapDefaultEndpoints();

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

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();
