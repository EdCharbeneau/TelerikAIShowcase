using Microsoft.Extensions.AI;
using System.ComponentModel;

namespace AIShowcase.WebApp.Components.Pages.Chat;
public partial class Chat
{
	private string SystemPrompt = @"
        You are an assistant who answers questions about information you retrieve.
        
        Use only simple markdown to format your responses.

       When conducting a search using the search tool use HTML cite tags for referenced materials.
		";

	string? streamingText;
	List<ChatMessage> messages = new();
	ChatOptions chatOptions = new();
	ChatSuggestions? chatSuggestions;
	CancellationTokenSource? currentResponseCancellation;
	ChatInput? ChatInputRef;
	bool isThinking;

	// Lifecycle
	protected override async Task OnInitializedAsync()
	{

		chatOptions = new()
		{
			Tools = [
						AIFunctionFactory.Create(navigationTool.GetRoutes),
						AIFunctionFactory.Create(navigationTool.NavigateTo),
						AIFunctionFactory.Create(voiceSettingsTool.GetVoices),
						AIFunctionFactory.Create(voiceSettingsTool.SetVoice),
						AIFunctionFactory.Create(SearchAsync)
					]
		};
		await NewChat();
	}

	async Task CreateListeningMessage()
	{
		//if (settings is null || audioPlayer is null) return;
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
		if (ChatInputRef is not null && helloMessage.Message.Text is string)
		{
			await ChatInputRef.PlaySpeech(helloMessage.Message.Text);
		}
	}
	async Task RespondWithSpeech(ChatMessage userMessage)
	{

		// Rephrase the user's question so the spoken response is more concise.
		// This reduces the amount of text the SST service needs to process.
		// This also reduces the time it takes to speak the response.
		string newPrompt = $@"
			The user asked a question using their voice
			<question>{userMessage.Text}</question>.
			Please respond in a concise single paragraph using plain text.
			";

		ChatMessage modifiedMessage = new(ChatRole.User, newPrompt);
		await BeginThinking();
		// Get a chat response with the augmented message
		ChatResponse response = await ai.GetResponseAsync([.. messages, modifiedMessage], chatOptions);
		await EndThinking();
		// add the original user message and the response to the chat
		messages.Add(userMessage);
		// add the response to the chat
		messages.Add(new(ChatRole.Assistant, response.Message.Text));
		// Speak the response to the user

		if (ChatInputRef is not null && response.Message.Text is string)
		{
			await ChatInputRef.PlaySpeech(response.Message.Text);
		}
	}

	async Task RespondWithStreamingText(ChatMessage userMessage)
	{
		// Add the user message to the conversation
		messages.Add(userMessage);
		messages.Add(new ChatMessage(ChatRole.System, "Use HTML citations to reference materials. Format pdf file citation links with view-pdf?file=Data/{file_name}&page={page_number}&term={exact quote}"));
		chatSuggestions?.Clear();

		// Stream and display a new response from the IChatClient
		var responseText = new TextContent("");
		var currentResponseMessage = new ChatMessage(ChatRole.Assistant, [responseText]);
		currentResponseCancellation = new();
		await BeginThinking();
		await foreach (var chunk in ai.GetStreamingResponseAsync(messages, chatOptions, currentResponseCancellation.Token))
		{
			responseText.Text += chunk.Text;
			streamingText = responseText.Text;
			StateHasChanged();
		}
		await EndThinking();
		// Store the final response in the conversation, and begin getting suggestions
		messages.Add(currentResponseMessage!);
		currentResponseMessage = null;
		streamingText = null;
		chatSuggestions?.Update(messages);
	}

	async Task BeginThinking()
	{
		chatSuggestions?.Clear();
		isThinking = true;
		await Task.CompletedTask;
	}

	async Task EndThinking()
	{
		if(messages.Count > 0) chatSuggestions?.Update(messages);
		isThinking = false;
		await Task.CompletedTask;
	}

	async Task NewChat()
	{
		ChatMessage system = new(ChatRole.System, SystemPrompt);
		await BeginThinking();
		ChatResponse response = await ai.GetResponseAsync([system]);
		await EndThinking();
	}

	async Task RestartChat()
	{
		messages = [];
		await NewChat();
	}
	async Task SubmitImage(ChatMessage imageMessage)
	{
		messages.Add(imageMessage);

		await BeginThinking();
		ChatResponse response = await ai.GetResponseAsync(imageMessage);
		messages.Add(new ChatMessage(ChatRole.Assistant, response.Message.Text));
		await EndThinking();
	}

	[Description("Searches for information using a phrase or keyword")]
	private async Task<IEnumerable<string>> SearchAsync(
[Description("The phrase to search for.")] string searchPhrase,
[Description("Whenever possible, specify the filename to search that file only. If not provided, the search includes all files.")] string? filenameFilter = null)
	{
		await InvokeAsync(StateHasChanged);
		var results = await Search.SearchAsync(searchPhrase, filenameFilter, maxResults: 5);
		var final = results.Select(result =>
			$"<result filename=\"{result.FileName}\" page_number=\"{result.PageNumber}\">{result.Text}</result>");
		return final;
	}
}
