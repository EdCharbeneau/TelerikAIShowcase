using AIShowcase.WebApp.MenuData;
using AIShowcase.WebApp.Services;
using AIShowcase.WebApp.Services.TextToSpeechServices;
using Microsoft.AspNetCore.Components;
using ProgressSyntha;
using System.ComponentModel;

namespace AIShowcase.WebApp.Components.Pages.Chat
{

	public class NavigationTool(NavigationManager navigationManager, MenuVectorData menuVectorData)
	{
		MainMenu menu = new();
		bool initialized = false;

		[Description("Used to navigate to application features. " +
			"Only navigate to items that exist in Get Pages." +
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
			var search = await menuVectorData.Search(route);
			var first = await search.Results.FirstOrDefaultAsync();
			//Console.WriteLine($"Vector result:{first?.Score}");
			if (first is null || first.Score < .5)
			{
				return "Cannot navigate";
			}
			//Console.WriteLine($"Vector result:{first.Record.Url}");
			navigationManager.NavigateTo(first.Record.Url);
			return first.Record.Url;
		}

		[Description("A list of pages in this application.")]
		public string[] GetPages()
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
			settings.SetSelectedVoiceId(selected.Id);
			return "Voice set";
		}
	}

	public class SynthaTool(SynthaClient client)
	{
		[Description("Searches documents for answers")]
		public async Task<string> Ask(string query)
		{
			var results = client.Ask(query);
			string text = "";
			await foreach (var item in results)
			{
				if(item.Item is AnswerContent answer)
				{
					text += answer.Text;
				}
			}
			return text;
		}
	}

}
