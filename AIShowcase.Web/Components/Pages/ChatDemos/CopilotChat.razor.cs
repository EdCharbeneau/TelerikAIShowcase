using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.AI;
using Telerik.Blazor.Components;

namespace AIShowcase.WebApp.Components.Pages.ChatDemos;
public partial class CopilotChat
{
	// Lifecycle
	protected override async Task OnInitializedAsync()
	{
		await NewChat();
	}

	#region Prompt
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

	Task OnRecognizedText(string value)
	{
		Prompt = value;
		return AddMessage();
	}
	#endregion

	#region Messages
	string streamingText = "";
	List<ChatMessage> messages = [];

	async Task AddMessage()
	{
		ChatMessage userMessage = new()
		{
			Role = ChatRole.User,
			Text = Prompt,
			AuthorName = "You"
		};

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
			messages.Add(new ChatMessage
			{
				Role = ChatRole.Assistant,
				Text = streamingText
			});
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
		var system = new ChatMessage
		{
			Role = ChatRole.System,
			Text = "Greet the user in a friendly way, make them feel welcome."
		};

		await BeginThinking(async () =>
		{
			ChatResponse response = await ai.GetResponseAsync(system);

			messages.Add(response.Message);
		});
	}
	#endregion

}
