using AIShowcase.WebApp.Services.TextToSpeechServices;

namespace AIShowcase.WebApp.Services;

public class ApplicationSettings(ITextToSpeechService tts)
{

    public Voice? SelectedVoice { get; set; }

    public event Action? OnChange;

    public async Task InitializeSettings()
    {
        await InitializeVoices();
    }

    private async Task InitializeVoices()
    {
        if (SelectedVoice is null)
        {
            var voices = await tts.GetVoices();
            SelectedVoice = voices.FirstOrDefault(v => v.DisplayName.Contains("Nova"));
            if (SelectedVoice is null)
            {
                if (voices.Length > 0)
                {
                    var random = new Random();
                    SelectedVoice = voices[random.Next(voices.Length)];
                }
            }
        }
        NotifyStateChanged();
    }

    public void SetSelectedVoice(Voice voice)
    {
		SelectedVoice = voice;
		NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
