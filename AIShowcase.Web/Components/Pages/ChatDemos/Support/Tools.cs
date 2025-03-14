using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.AI;
using System.ComponentModel;

namespace AIShowcase.WebApp.Components.Pages.ChatDemos.Support
{
	public static class Tools
	{
		public static AITool GetRoutingTool()
		{
			var tool = AIFunctionFactory.Create(NavigationTool.GetRoutes);
			return tool;
		}

		public static AITool GetNavigationTool(NavigationManager navigationManager)
		{
			var t = new NavigationTool(navigationManager); 
			var tool = AIFunctionFactory.Create(t.NavigateTo);
			return tool;
		}

	}

	public class NavigationTool(NavigationManager navigationManager)
	{

		[Description("Used to navigate to application features. Only navigate to items that exist in Get Routes. Routes must be hyphenated.")]
		public string? NavigateTo(string route)
		{
			Console.WriteLine(route);
			if (!GetRoutes().Contains(route)) return "invalid route";
			navigationManager.NavigateTo(route);
			return route;
		}

		// TODO: Add a vector search to this method to make it more flexible
		// TODO: Or call the LLM again to have it use natural language to determine the route
		[Description("A list of routes in this application.")]
		public static string[] GetRoutes()
		{
			Console.WriteLine("GetRoutes called");

			return new string[] { "basic-chat", "speech-to-text", "text-to-speech" };
		}
	}
}
