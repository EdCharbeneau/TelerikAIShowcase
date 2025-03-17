namespace AIShowcase.WebApp.Services.TextToSpeechServices
{
	public interface ITextToSpeechService
	{
		string Name { get; }
		Task<byte[]> GetSpeech(string text, string voiceId, string? culture = null);
		Task<string> GetSpeechAsBase64String(string text, string voiceId, string? culture = null);
		Task<Voice[]> GetVoices(string? culture = null);
		bool IsConfigured { get; }
	}
}