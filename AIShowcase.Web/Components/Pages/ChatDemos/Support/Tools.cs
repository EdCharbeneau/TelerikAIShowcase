using AIShowcase.WebApp.Support;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.AI;
using System.Collections.Generic;
using System.ComponentModel;

namespace AIShowcase.WebApp.Components.Pages.ChatDemos.Support
{

	public class NavigationTool(NavigationManager navigationManager, MenuVectorData menuVectorData)
	{
		MainMenu menu = new();
		bool initialized;

		[Description("Used to navigate to application features. " +
			"Only navigate to items that exist in Get Routes." +
			"The tool responds with `Cannot navigate` if no route is available."
			)]
		public async Task<string?> NavigateTo(string route)
		{
			Console.WriteLine($"AI passed{route}");
			if (!initialized)
			{
				await menuVectorData.CreateVectorDataSource(menu.Items);
			}
			var search = await menuVectorData.Search(route);
			var first = await search.Results.FirstOrDefaultAsync();
			Console.WriteLine($"Vector result:{first?.Score}");
			if (first is null || first.Score < .5)
			{
				return "Cannot navigate";
			}
			Console.WriteLine($"Vector result:{first.Record.Url}");
			//navigationManager.NavigateTo(first.Record.Url);
			return first.Record.Url;
		}

		// TODO: Add a vector search to this method to make it more flexible
		// TODO: Or call the LLM again to have it use natural language to determine the route
		[Description("A list of routes in this application.")]
		public string[] GetRoutes()
		{
			return menu.Items.Select(m=>m.Text).ToArray();
		}
	}
}
