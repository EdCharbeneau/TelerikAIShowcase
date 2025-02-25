using AIShowcase.WebApp.Components.TextToSpeechServices;

namespace AIShowcase.WebApp;
public static class SpeechServicesExtensions
{
	public static IServiceCollection AddAllSpeechServices(this IServiceCollection services)
	{
		services.AddScoped<ITextToSpeechService, AzureTextToSpeechService>();
		services.AddScoped<ITextToSpeechService, ElevenLabsTextToSpeechService>();
		services.AddSpeechSynthesisServices();
		return services;
	}
}