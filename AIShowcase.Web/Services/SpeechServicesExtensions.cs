using AIShowcase.WebApp.Components.Generic;
using AIShowcase.WebApp.Services.TextToSpeechServices;

namespace AIShowcase.WebApp.Services;
public static class SpeechServicesExtensions
{
	public static IServiceCollection AddSpeechServices(this IServiceCollection services)
	{
		services.AddScoped<ITextToSpeechService, AzureTextToSpeechService>();
		//services.AddScoped<ITextToSpeechService, ElevenLabsTextToSpeechService>();
		services.AddScoped<AudioPlayerInterop>();
		//services.AddSpeechSynthesisServices();
		return services;
	}
}