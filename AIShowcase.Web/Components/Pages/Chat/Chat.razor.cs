using Microsoft.Extensions.AI;
using System.ComponentModel;

namespace AIShowcase.WebApp.Components.Pages.Chat;
public partial class Chat
{
	private string SystemPrompt = @"
        You are an assistant who answers questions about information you retrieve.
		Additional capabilities are provided by tools.
        
        Use only simple markdown to format your responses.
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
   "), chatOptions);
		if (ChatInputRef is not null && helloMessage.Text is not null)
		{
			await ChatInputRef.PlaySpeech(helloMessage.Text);
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
		messages.Add(new(ChatRole.Assistant, response.Text));
		// Speak the response to the user

		if (ChatInputRef is not null && response.Text is string)
		{
			await ChatInputRef.PlaySpeech(response.Text);
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
		chatSuggestions?.Update(messages);
		isThinking = false;
		await Task.CompletedTask;
	}

	async Task NewChat()
	{
		await BeginThinking();
		ChatMessage system = new(ChatRole.System, SystemPrompt);
		messages.Add(system);
		ChatResponse systemResponse = await ai.GetResponseAsync(messages, chatOptions);
		ChatMessage userPrompt = new(ChatRole.User, "What features does this app have? Provide an ordered list with a description. Example: - **Feature**: Feature description...");
		ChatResponse response = await ai.GetResponseAsync([..messages, userPrompt], chatOptions);
		messages.AddMessages(response);
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
		ChatResponse response = await ai.GetResponseAsync(imageMessage, chatOptions);
		messages.Add(new ChatMessage(ChatRole.Assistant, response.Text));
		await EndThinking();
	}
}
