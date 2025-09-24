using AIShowcase.WebApp.MenuData;
using AIShowcase.WebApp.Services;
using AIShowcase.WebApp.Services.TextToSpeechServices;
using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace AIShowcase.WebApp.Components.Pages.Chat
{

	public class NavigationTool(NavigationManager navigationManager, MenuVectorData menuVectorData)
	{
		MainMenu menu = new();
		bool initialized = false;

		[Description("Used to navigate to application features. " +
			"Only navigate to items that exist in get features." +
			"The tool responds with `Cannot navigate` if no route is available."
			)]
		public async Task<string?> NavigateTo(string route)
		{
			//Console.WriteLine($"AI passed {route}");
			if (!initialized)
			{
				await menuVectorData.CreateVectorDataSource(menu.Items);
				initialized = true;
			}
			var searchResult = await menuVectorData.Search(route);
			if (searchResult is null || searchResult.Score < .5)
			{
				return "Cannot navigate";
			}
			navigationManager.NavigateTo(searchResult.Record.Url);
			return searchResult.Record.Url;
		}

		[Description("A list of application features in this application.")]
		public string[] GetRoutes()
		{
			return menu.Items.Select(m => m.Text).ToArray();
		}
	}

	public class VoiceSettingsTool(ApplicationSettings settings, ITextToSpeechService tts)
	{
		[Description("Get a list of voices from the speech provider.")]
		public async Task<string[]> GetVoices()
		{
			var voices = await tts.GetVoices();
			return voices.Select(v => v.DisplayName).ToArray();
		}

		[Description("Set the voice for the application.")]
		public async Task<string> SetVoice(string voice)
		{
			var voices = await tts.GetVoices();
			var selected = voices.FirstOrDefault(v => v.DisplayName.Contains(voice, StringComparison.OrdinalIgnoreCase));
			if (selected is null)
				return "Voice not found";
			settings.SetSelectedVoice(selected);
			return "Voice set";
		}
	}

}
