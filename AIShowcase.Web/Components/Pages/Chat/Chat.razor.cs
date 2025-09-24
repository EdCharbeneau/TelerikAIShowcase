using AIShowcase.WebApp.Components.Generic;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.AI;
using System.ComponentModel;
using Telerik.Blazor.Components;


namespace AIShowcase.WebApp.Components.Pages.Chat;
public partial class Chat
{
	private const string SystemPrompt = @"
        You are an assistant who answers questions about information you retrieve.
        Do not answer questions about anything else.
        Use only simple markdown to format your responses.

        Use the search tool to find relevant information. When you do this, end your
        reply with citations in the special XML format:

        <citation filename='string' page_number='number'>exact quote here</citation>

        Always include the citation in your response if there are results.

        The quote must be max 5 words, taken word-for-word from the search result, and is the basis for why the citation is relevant.
        Don't refer to the presence of citations; just emit these tags right at the end, with no surrounding text.
        ";
	ChatOptions chatOptions = new();
	ChatSuggestions? chatSuggestions;
	TelerikFileSelect? UploadRef;
	CancellationTokenSource? currentResponseCancellation;

	// Lifecycle
	protected override async Task OnInitializedAsync()
	{

		chatOptions = new()
		{
			Tools = [
						AIFunctionFactory.Create(navigationTool.GetPages),
						AIFunctionFactory.Create(navigationTool.NavigateTo),
						AIFunctionFactory.Create(voiceSettingsTool.GetVoices),
						AIFunctionFactory.Create(voiceSettingsTool.SetVoice),
						AIFunctionFactory.Create(synthaTool.Ask),
						//AIFunctionFactory.Create(SearchAsync)
					]
		};
		await NewChat();
	}
	public void Dispose()
	{
		settings.OnChange -= StateHasChanged;
	}

	#region Voice

	public bool isAudioPlaying;
	SpeechToTextButton? Microphone;
	AudioPlayer? audioPlayer;
	async Task CreateListeningMessage()
	{
		if (settings is null || audioPlayer is null) return;
		var helloMessage = await ai.GetResponseAsync(new ChatMessage
		(
			ChatRole.System,
			@"
   You are an AI assistant. 
   Let the user know you're listening with a single text only sentence.
   Here are some examples:
   <example>Hello, how are you today?</example>
   <example>What's on your mind?</example>
   <example>What can I help with?</example>
   <example>I'm here to help.</example>
   "));
		await PlaySpeech(helloMessage.Text);
	}
	Task OnRecordClick() => CreateListeningMessage();
	async Task OnRecognizedText(string value)
	{
		Prompt = value;
		await RespondWithSpeech();
	}
	async Task OnStopAudio()
	{
		isAudioPlaying = false;
		await audioPlayer!.Stop();
	}

	async Task RespondWithSpeech()
	{
		await Microphone!.StopRecording();

		ChatMessage userMessage = GetUserChatMessage();

		// Rephrase the user's question so the spoken response is more concise.
		// This reduces the amount of text the SST service needs to process.
		// This also reduces the time it takes to speak the response.
		string newPrompt = $@"
			The user asked a question using their voice
			<question>{userMessage.Text}</question>.
			Please respond in a concise single paragraph using plain text.
			";

		ChatMessage augmentedessage = new(ChatRole.User, newPrompt);

		await BeginThinking(async () =>
		{
			// Get a chat response with the augmented message
			ChatResponse response = await ai.GetResponseAsync([.. messages, augmentedessage], chatOptions);
			// add the original user message and the response to the chat
			messages.Add(userMessage);
			// add the response to the chat
			messages.Add(new(ChatRole.Assistant, response.Text));
			// Speak the response to the user
			
		});
			await PlaySpeech(messages.Last().Text);
	}

	private async Task PlaySpeech(string text)
	{
		if (settings.SelectedVoiceId is null || audioPlayer is null) return;
		string speech = await tts.GetSpeechAsBase64String(text, settings.SelectedVoiceId);
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

	ChatMessage GetUserChatMessage()
	{
		var userMessage = new ChatMessage(ChatRole.User, Prompt);
		Prompt = "";
		return userMessage;
	}

	Task SubmitOnEnter(KeyboardEventArgs args)
	{
		if (args.Key == "Enter" && !args.ShiftKey && canSubmit)
		{
			return SubmitMessage();
		}
		return Task.CompletedTask;
	}

	#endregion

	#region Messages
	TextContent streamingText = new("");
	List<ChatMessage> messages = [];

	Task SubmitMessage() => RespondWithStreamingText(GetUserChatMessage());

	async Task RespondWithStreamingText(ChatMessage userMessage)
	{
		messages.Add(userMessage);
        currentResponseCancellation = new();
			messages.Add(new ChatMessage(ChatRole.Assistant, [streamingText]));
			IAsyncEnumerable<ChatResponseUpdate> responseStream = ai.GetStreamingResponseAsync(messages, chatOptions, currentResponseCancellation.Token);

			await foreach (var message in responseStream)
			{
				streamingText.Text += message.Text;
				StateHasChanged();
			}
			streamingText = new("");
	}
	#endregion

	#region Thinking
	bool isThinking;

	/// <summary>
	/// Wraps an AI request process with a loading indicator.
	/// This method also clears and updates the chat suggestions.
	/// </summary>
	/// <param name="action"></param>
	/// <returns></returns>
	async Task BeginThinking(Func<Task> action)
	{
		chatSuggestions?.Clear();
		isThinking = true;
		try
		{
			await action();
			chatSuggestions?.Update(messages);
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
			PopupRef?.Hide();
		}
		else
		{
			PopupRef?.Show();
		}
		popupVisible = !popupVisible;
	}

	async Task RestartChat()
	{
		messages = [];
		TogglePopup();
		await NewChat();
	}

	async Task NewChat()
	{
		ChatMessage system = new(ChatRole.System, SystemPrompt);

		await BeginThinking(async () =>
		{
			ChatResponse response = await ai.GetResponseAsync(system);
			//messages.Add(new ChatMessage(ChatRole.Assistant, response.Text));
		});
	}
	async Task OnFileSelect(FileSelectEventArgs args)
	{
		PopupRef?.Hide();
		if (UploadRef is null) return;

		var file = args.Files[0];

		byte[]? imgBytes = null;

		// Fully flush out the uploaded file Stream into a MemoryStream then copy into the byte[]
		using var ms = new MemoryStream();
		await file.Stream.CopyToAsync(ms);
		imgBytes = ms.ToArray();

		ChatMessage fileMessage = new(ChatRole.User, "What's in this image?");
		fileMessage.Contents.Add(new DataContent(imgBytes, "image/jpg"));

		messages.Add(fileMessage);

		await BeginThinking(async () =>
		{
			StateHasChanged();
			ChatResponse response = await ai.GetResponseAsync(fileMessage);
			messages.Add(new ChatMessage(ChatRole.Assistant, response.Text));
		});
	}

	[Description("Searches for information using a phrase or keyword")]
	private async Task<IEnumerable<string>> SearchAsync(
	[Description("The phrase to search for.")] string searchPhrase,
	[Description("Whenever possible, specify the filename to search that file only. If not provided, the search includes all files.")] string? filenameFilter = null)
	{
		await InvokeAsync(StateHasChanged);
		var results = await searchTool.SearchAsync(searchPhrase, filenameFilter, maxResults: 5);
		return results.Select(result =>
			$"<result filename=\"{result.FileName}\" page_number=\"{result.PageNumber}\">{result.Text}</result>");
	}
	#endregion
}
