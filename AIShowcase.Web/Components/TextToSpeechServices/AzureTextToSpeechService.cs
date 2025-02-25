using AIShowcase.WebApp.Common;
using Microsoft.CognitiveServices.Speech;

namespace AIShowcase.WebApp.Components.TextToSpeechServices;

public class AzureTextToSpeechService : ITextToSpeechService
{
	public string Name => "Azure";
	private readonly string speechApiKey;
	private readonly string serviceRegion;

	bool isConfigured;
	public bool IsConfigured => isConfigured;


	public AzureTextToSpeechService(IConfiguration config)
	{
		speechApiKey = config["SpeechApiKey"]
			?? "";
		serviceRegion = config["ServiceRegion"]
			?? "";
		isConfigured = !(string.IsNullOrWhiteSpace(speechApiKey) && string.IsNullOrWhiteSpace(serviceRegion));
	}

	public async Task<byte[]> GetSpeech(string text, string voiceId, string culture = "en-US")
	{
		if (!isConfigured) throw new InvalidOperationException("AzureTextToSpeechService was not configured.");
		var speechConfig = SpeechConfig.FromSubscription(speechApiKey, serviceRegion);
		speechConfig.SpeechSynthesisLanguage = culture;
		speechConfig.SpeechSynthesisVoiceName = voiceId;

		using var synthesizer = new SpeechSynthesizer(speechConfig, null);
		var result = await synthesizer.SpeakTextAsync(text);

		if (result.Reason == ResultReason.Canceled)
		{
			var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
			Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");
			Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
			Console.WriteLine($"CANCELED: ErrorDetails={cancellation.ErrorDetails}");
			Console.WriteLine($"CANCELED: Did you update the subscription info?");
			return [];
		}

		return result.AudioData;


	}

	public async Task<string> GetSpeechAsBase64String(string text, string voiceId, string culture = "en-US")
		=> AsString(await GetSpeech(text, voiceId));

	private static string AsString(byte[] audioAsBytes)
	{
		// Convert the byte array to a base64 string
		string base64String = Convert.ToBase64String(audioAsBytes);
		string audio = $"data:audio/mp3;base64,{base64String}";
		return audio;
	}

	public async Task<Voice[]> GetVoices(string culture = "")
	{
		if (!isConfigured) throw new InvalidOperationException("AzureTextToSpeechService was not configured.");

		var speechConfig = SpeechConfig.FromSubscription(speechApiKey, serviceRegion);
		using var synthesizer = new SpeechSynthesizer(speechConfig, null);
		var response = await synthesizer.GetVoicesAsync(culture);
		return response.Voices.Select(v => new Voice(v.LocalName, v.Name)).ToArray();
	}

	public Task<Voice[]> GetVoices()
	{
		throw new NotImplementedException();
	}
}