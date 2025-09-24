namespace AIShowcase.WebApp.Components.Pages.ChatBot;
public class UIChatMessage
{
	public string? Id { get; set; } = Guid.NewGuid().ToString();
	public string? AuthorId { get; set; }

	public string? AuthorName { get; set; }

	public string? AuthorImageUrl { get; set; }

	public string? Content { get; set; }

	public string Status { get; set; } = "Sent";

	public bool IsDeleted { get; set; }

	public bool IsPinned { get; set; }

	public DateTime Timestamp { get; set; } = DateTime.Now;

	//public List<string> SuggestedActions { get; set; }

	public static UIChatMessage AssistantMessage(string content) => new UIChatMessage()
	{
		AuthorId = "ai",
		AuthorName = "AI Assistant",
		AuthorImageUrl = "https://demos.telerik.com/blazor-ui/images/devcraft-ninja-small.svg",
		Content = content,
	};

	public static UIChatMessage UserMessage(string content) => new UIChatMessage()
	{
		AuthorId = "user",
		AuthorName = "Your Message",
		Content = content,
	};
}