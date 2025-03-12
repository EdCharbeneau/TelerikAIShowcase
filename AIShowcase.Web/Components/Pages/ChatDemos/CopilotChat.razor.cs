using AIShowcase.WebApp.Components.Generic;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.AI;
using Telerik.Blazor.Components;

namespace AIShowcase.WebApp.Components.Pages.ChatDemos;
public partial class CopilotChat
{
	// Lifecycle
	protected override async Task OnInitializedAsync()
	{
		var voices = await tts.GetVoices();
		if (voices.Length == 0)
		{
			throw new InvalidOperationException("Voices were not loaded or selected");
		}
		selectedVoiceId = "Microsoft Server Speech Text to Speech Voice (en-US, NovaTurboMultilingualNeural)";

		await NewChat();
	}

	#region Prompt
	public bool isPlaying;
	public string? selectedVoiceId;
	SpeechToTextButton? Recorder;
	AudioPlayer? AudioAPI;
	string? Prompt { get; set; }
	bool canSubmit => !string.IsNullOrWhiteSpace(Prompt) && !isThinking;

	/// <summary>
	/// Captures the Enter key press event and triggers the AddMessage method if the Enter key is pressed without the Shift key.
	/// </summary>
	/// <param name="args">The keyboard event arguments.</param>
	/// <returns>A task representing the asynchronous operation.</returns>
	Task SubmitOnEnter(KeyboardEventArgs args)
	{
		// Captures enter but not shift + enter
		if (args.Key == "Enter" && !args.ShiftKey)
		{
			if (canSubmit)
				return AddMessage();
		}
		return Task.CompletedTask;
	}

	async Task CreateListeningMessage()
	{
		if (selectedVoiceId is null || AudioAPI is null) return;
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
		var speech = await tts.GetSpeechAsBase64String(helloMessage.Text, selectedVoiceId);
		await AudioAPI.Load(speech);
		isPlaying = true;
		await AudioAPI.Play();
	}

	async Task OnRecordClick()
	{
		// Speak > "Hello, I'm listening"
		await CreateListeningMessage();
	}

	Task OnRecognizedText(string value)
	{
		Prompt = value;
		return RespondWithSpeech();
	}

	Task OnStopAudio()
	{
		isPlaying = false;
		// If audio is playing AudioAPI cannot be null
		return AudioAPI!.Stop();

	}

	//Create a shorter response to allow for better conversation
	async Task RespondWithSpeech()
	{
		// Recorder can't be null here
		await Recorder!.StopRecording();

		ChatMessage userMessage = new(
		 ChatRole.User,
		 Prompt
		);

		Prompt = "";

		await BeginThinking(async () =>
		{
			string newPrompt = $"""
			The user asked a question using their voice
			<question>{userMessage.Text}</question>.
			Please respond in a concise single paragraph using plain text.
			""";
			ChatMessage augmentedPrompt = new(
				ChatRole.User,
				newPrompt);

			//todo: make this use streaming
			//for streaming we'll need to chunk the responses into completed paragraphs
			//then generate a wav for each chunk
			//the files will need to be played in order and the playlist will need to be updated as items play

			var response = await ai.GetResponseAsync([.. messages, augmentedPrompt]);

			messages.Add(userMessage);
			messages.Add(new ChatMessage(
				ChatRole.Assistant,
				response.Text
			));

			if (selectedVoiceId is null || AudioAPI is null) return;
			{
				var speech = await tts.GetSpeechAsBase64String(response.Text, selectedVoiceId);
				await AudioAPI.Load(speech);
				isPlaying = true;
				await AudioAPI.Play();
			}
		});
	}

	/// <summary>
	/// Starts recording after ever audio track is played
	/// </summary>
	/// <returns></returns>
	async Task OnEnded()
	{
		isPlaying = false;
		if (Recorder is null) return;
		await Recorder.StartRecording();
		StateHasChanged();
	}
	#endregion

	#region Messages
	string streamingText = "";
	List<ChatMessage> messages = [];

	async Task AddMessage()
	{
		ChatMessage userMessage = new(
			ChatRole.User,
			Prompt
		);

		messages.Add(userMessage);
		Prompt = "";

		await BeginThinking(async () =>
		{
			var responseStream = ai.GetStreamingResponseAsync(messages);

			await foreach (var message in responseStream)
			{
				streamingText = streamingText + message.Text;
				StateHasChanged();
			}
			messages.Add(new ChatMessage(
				ChatRole.Assistant,
				streamingText
			));
			streamingText = "";
		});
	}
	#endregion

	#region Thinking
	bool isThinking;

	/// <summary>
	/// Sets the isThinking flag to true, executes the provided action, and then sets the isThinking flag to false.
	/// </summary>
	/// <param name="action">The asynchronous action to be executed while thinking.</param>
	/// <returns>A task representing the asynchronous operation.</returns>
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
		var system = new ChatMessage(
			ChatRole.System,
			"Greet the user in a friendly way, make them feel welcome."
		);

		await BeginThinking(async () =>
		{
			ChatResponse response = await ai.GetResponseAsync(system);

			messages.Add(response.Messages[0]);
		});
	}
	#endregion

}
