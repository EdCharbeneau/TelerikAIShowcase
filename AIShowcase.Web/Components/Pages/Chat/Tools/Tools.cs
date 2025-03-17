using AIShowcase.WebApp.MenuData;
using Microsoft.AspNetCore.Components;
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
			return menu.Items.Select(m=>m.Text).ToArray();
		}
	}
}
