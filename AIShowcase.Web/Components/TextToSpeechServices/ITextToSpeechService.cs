
namespace AIShowcase.WebApp.Components.TextToSpeechServices
{
	public interface ITextToSpeechService
	{
		string Name { get; }
		Task<byte[]> GetSpeech(string text, string voiceId, string culture);
		Task<string> GetSpeechAsBase64String(string text, string voiceId, string culture);
		Task<Voice[]> GetVoices(string culture);
		bool IsConfigured { get; }
	}
}