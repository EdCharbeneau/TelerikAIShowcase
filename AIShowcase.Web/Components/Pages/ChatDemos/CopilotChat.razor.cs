using AIShowcase.WebApp.Components.Generic;
using AIShowcase.WebApp.Components.Pages.ChatDemos.Support;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.AI;
using Telerik.Blazor.Components;

namespace AIShowcase.WebApp.Components.Pages.ChatDemos;
public partial class CopilotChat(NavigationManager navigation)
{
	// Global TODO: Move to settings or configuration
	public string? selectedVoiceId = "Microsoft Server Speech Text to Speech Voice (en-US, NovaTurboMultilingualNeural)";

	// Lifecycle
	protected override Task OnInitializedAsync() => NewChat();

	#region Voice

	public bool isAudioPlaying;
	SpeechToTextButton? Microphone;
	AudioPlayer? audioPlayer;
	async Task CreateListeningMessage()
	{
		if (selectedVoiceId is null || audioPlayer is null) return;
		var helloMessage = await ai.GetResponseAsync(new ChatMessage
		(
			ChatRole.System,
			"""
   You are an AI assistant. 
   Let the user know you're listening with a single text only sentence.
   Here are some examples:
   <example>Hello, how are you today?</example>
   <example>What's on your mind?</example>
   <example>What can I help with?</example>
   <example>I'm here to help.</example>
   """));
		await PlaySpeech(helloMessage.Text);
	}
	Task OnRecordClick() => CreateListeningMessage();
	Task OnRecognizedText(string value)
	{
		Prompt = value;
		return RespondWithSpeech();
	}
	Task OnStopAudio()
	{
		isAudioPlaying = false;
		return audioPlayer!.Stop();
	}

	async Task RespondWithSpeech()
	{
		await Microphone!.StopRecording();
		ChatOptions chatOptions = new()
		{
			Tools = [
		AIFunctionFactory.Create(navigationTool.GetRoutes),
		AIFunctionFactory.Create(navigationTool.NavigateTo),
		]
		};

		ChatMessage userMessage = new(ChatRole.User, Prompt);
		Prompt = "";

		await BeginThinking(async () =>
		{
			string newPrompt = $"""
			The user asked a question using their voice
			<question>{userMessage.Text}</question>.
			Please respond in a concise single paragraph using plain text.
			""";
			ChatMessage augmentedPrompt = new(ChatRole.User, newPrompt);

			ChatResponse response = await ai.GetResponseAsync([.. messages, augmentedPrompt], chatOptions);

			messages.Add(userMessage);
			messages.Add(new(ChatRole.Assistant, response.Text));

			await PlaySpeech(response.Text);
		});
	}

	private async Task PlaySpeech(string text)
	{
		if (selectedVoiceId is null || audioPlayer is null) return;
		string speech = await tts.GetSpeechAsBase64String(text, selectedVoiceId);
		await audioPlayer.Load(speech);
		isAudioPlaying = true;
		await audioPlayer.Play();
	}

	async Task OnAudioEnded()
	{
		isAudioPlaying = false;
		if (Microphone is null) return;
		await Microphone.StartRecording();
	}

	#endregion

	#region Prompt

	string? Prompt { get; set; }
	bool canSubmit => !string.IsNullOrWhiteSpace(Prompt) && !isThinking;

	Task SubmitOnEnter(KeyboardEventArgs args)
	{
		if (args.Key == "Enter" && !args.ShiftKey && canSubmit)
		{
			return AddMessage();
		}
		return Task.CompletedTask;
	}

	#endregion

	#region Messages
	string streamingText = "";
	List<ChatMessage> messages = [];

	async Task AddMessage()
	{
		ChatMessage userMessage = new(ChatRole.User, Prompt);
		messages.Add(userMessage);
		Prompt = "";

		await BeginThinking(async () =>
		{
			IAsyncEnumerable<ChatResponseUpdate> responseStream = ai.GetStreamingResponseAsync(messages);

			await foreach (var message in responseStream)
			{
				streamingText += message.Text;
				StateHasChanged();
			}
			messages.Add(new ChatMessage(ChatRole.Assistant, streamingText));
			streamingText = "";
		});
	}
	#endregion

	#region Thinking
	bool isThinking;

	async Task BeginThinking(Func<Task> action)
	{
		isThinking = true;
		try
		{
			await action();
		}
		finally
		{
			isThinking = false;
		}
	}
	#endregion

	#region Popup Menu
	private TelerikPopup? PopupRef;
	private bool popupVisible = false;

	private void TogglePopup()
	{
		if (popupVisible)
		{
			HidePopup();
		}
		else
		{
			ShowPopup();
		}
	}

	private void HidePopup()
	{
		PopupRef?.Hide();
		popupVisible = false;
	}

	private void ShowPopup()
	{
		PopupRef?.Show();
		popupVisible = true;
	}

	async Task RestartChat()
	{
		messages = [];
		HidePopup();
		await NewChat();
	}

	async Task NewChat()
	{
		ChatMessage system = new(ChatRole.System, "Greet the user in a friendly way, make them feel welcome.");

		await BeginThinking(async () =>
		{
			ChatResponse response = await ai.GetResponseAsync(system);
			messages.Add(response.Messages[0]);
		});
	}
	#endregion
}
