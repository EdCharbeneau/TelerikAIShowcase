using ai_demos.Services.Ingestion;
using AIShowcase.WebApp.Components;
using AIShowcase.WebApp.Components.ChatOutputServices;
using AIShowcase.WebApp.MenuData;
using AIShowcase.WebApp.Services;
using Microsoft.Extensions.DependencyInjection;
using ProgressSyntha;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

builder.Services.AddSpeechRecognitionServices();

builder.AddDocumentSearchServices();

builder.AddChatServices();

builder.Services.AddSpeechServices();

builder.Services.AddSignalR(e => {
	e.MaximumReceiveMessageSize = 102400000;
});
// Register HttpClient
builder.Services.AddHttpClient();

builder.Services.AddScoped<MenuVectorData>();
builder.Services.AddScoped<ApplicationSettings>();
builder.Services.AddScoped<PrismInterop>();
builder.Services.AddTelerikBlazor();

var config = new SynthaConfig(ZoneId: "progress-proc-us-east-2-1",
	KnowledgeBaseId: "886a82a2-b0d6-400d-9907-9b8c0567681a",
	ApiKey: "eyJhbGciOiJSUzI1NiIsImtpZCI6InNhIiwidHlwIjoiSldUIn0.eyJpc3MiOiJodHRwczovL3Byb2dyZXNzLXByb2MtdXMtZWFzdC0yLTEuc3ludGhhLnByb2dyZXNzLmNvbS8iLCJpYXQiOjE3NDQ5MDUwODAsInN1YiI6IjE3M2VhZWViLWIxZDctNDYxNi1iOTY2LTY1ODZhZTJhOGRiNiIsImp0aSI6IjA2ZmJmOTQxLWYzMGYtNGIyMC05YjBhLTFkZDJkZWQyZWJiNCIsImV4cCI6MTc3NjQ0MTA3OCwia2V5IjoiODY3YWYzYWUtZjQ0OC00NjQxLTk1ZmEtNzg0NmVmMjQ0YmFlIiwia2lkIjoiOTI2MTQwZGYtNTU5OS00MTVkLWI4YzYtYjdjYjM0YmZjZjYxIn0.b2K9V0y2DhGvSj8ZiraQFO3bG8fyPU68DrKaIfw9-HV2qBWbFXEq2DA689RfRHSvKwiUM8d3l8PEbB_G-SzgWYGQdXhTlN1iE3LbSiGaseVAPuKfqU2v6rXH3ayQ9D4QuZUTnXpJziM97WUntmdUsnNOwr3WQ8okLWYf5cGhuefQi7meZ1xAnpxW99vkQVA0gOh_JBhAZfDgESZQESYgpQr-Iq1u-YKObBbP4R7Y_l3ZcjpW4Ne5LXgKlfkhDmc8cRx-2tv1izA2zccyFlQzzWPrAoLBdrcuKVqlFlfd1LhuNIS8tTTXQZuZRzSv2Nh0PP23z_Pd38L0fzrBYmUkkL_9BkI5XbO8EVGi_8Q2ESPcoUNaKYwDQPhalWivFKnyEdJUsNOXBgxnAyVOGuJVbrNJfyLNZ0K_eBBbtpoQTx7JsBIwAGHSKmW3H_n6KzNsmwKf-vhEzhxt_qAM_qmsfXSMfxe2eRFAPxz-vBfDFpfJ3epxtmXdrgwSfbfSLFLWTFId5f5hsvh_DahCBMJZhKvvCuPva8UiS-jAlf5DKH49cp7w6D35Hy1LmLXj5VmOOHr1hhu6gG0Im8hQEqacSBoMjXtj98bl1l0e6M_JUcBcawFzeXnEMRcoghns-agy9mv809nTlXir9Kb3AwguviXIaRhyi7rW9AruxFUu5Iw");

builder.Services.AddSingleton(config);
builder.Services.AddSingleton<SynthaClient>();

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

// By default, we ingest PDF files from the /wwwroot/Data directory. You can ingest from
// other sources by implementing IIngestionSource.
// Important: ensure that any content you ingest is trusted, as it may be reflected back
// to users or could be a source of prompt injection risk.
await DataIngestor.IngestDataAsync(
	app.Services,
	new PDFDirectorySource(Path.Combine(builder.Environment.WebRootPath, "Data")));

app.Run();
