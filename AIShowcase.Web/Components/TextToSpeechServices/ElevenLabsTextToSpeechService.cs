using ElevenLabs;
using ElevenLabs.TextToSpeech;

namespace AIShowcase.WebApp.Components.TextToSpeechServices;

public class ElevenLabsTextToSpeechService : ITextToSpeechService
{
	public string Name => "ElevenLabs";

	ElevenLabsClient? api;
	bool isConfigured;
	public bool IsConfigured => isConfigured;

	public ElevenLabsTextToSpeechService(IConfiguration config)
	{
		try
		{
			api = new ElevenLabsClient(config["ElevenLabsApiKey"]);
		}
		catch (Exception)
		{
			isConfigured = false;
		}
	}

	public async Task<byte[]> GetSpeech(string text, string voiceId, string? culture = null)
	{
		if (api is null) throw new InvalidOperationException("ElevenLabsApiKey is null, services is not configured");
		var voice = await api.VoicesEndpoint.GetVoiceAsync(voiceId);
		TextToSpeechRequest request = new TextToSpeechRequest(voice, text);
		VoiceClip voiceClip = await api.TextToSpeechEndpoint.TextToSpeechAsync(request);
		return voiceClip.ClipData.ToArray();
	}

	public async Task<string> GetSpeechAsBase64String(string text, string voiceId, string? culture = null)
		=> AsString(await GetSpeech(text, voiceId));

	private static string AsString(byte[] audioAsBytes)
	{
		// Convert the byte array to a base64 string
		string base64String = Convert.ToBase64String(audioAsBytes);
		string audio = $"data:audio/mp3;base64,{base64String}";
		return audio;
	}

	public async Task<Voice[]> GetVoices(string? culture = null)
	{
		if (api is null) throw new InvalidOperationException("ElevenLabsApiKey is null, services is not configured");
		var voices = await api.VoicesEndpoint.GetAllVoicesAsync();
		return voices.Select(v => new Voice(v.Name, v.Id)).ToArray();
	}

}
