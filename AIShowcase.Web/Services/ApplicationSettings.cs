using AIShowcase.WebApp.Services.TextToSpeechServices;
using System.Diagnostics.CodeAnalysis;

namespace AIShowcase.WebApp.Services;

public class ApplicationSettings(ITextToSpeechService tts)
{
    public string? SelectedVoiceId { get; set; }

    public event Action? OnChange;

    public async Task InitializeSettings()
    {
        await InitializeVoices();
    }

    private async Task InitializeVoices()
    {
        if (SelectedVoiceId is null)
        {
            var voices = await tts.GetVoices();
            SelectedVoiceId = voices.FirstOrDefault(v => v.DisplayName.Contains("Nova"))?.Id;
            if (SelectedVoiceId is null)
            {
                if (voices.Length > 0)
                {
                    var random = new Random();
                    SelectedVoiceId = voices[random.Next(voices.Length)].Id;
                }
            }
        }
        NotifyStateChanged();
    }

    public void SetSelectedVoiceId(string voiceId)
    {
        SelectedVoiceId = voiceId;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
