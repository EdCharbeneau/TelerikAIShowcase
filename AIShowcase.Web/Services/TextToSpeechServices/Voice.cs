namespace AIShowcase.WebApp.Services.TextToSpeechServices;
public class Voice
{
	public string DisplayName { get; set; } = "";
	public string Id { get; set; } = "";

	public Voice(string displayName, string id)
	{
		DisplayName = displayName;
		Id = id;
	}
}
