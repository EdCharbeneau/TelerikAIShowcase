using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace AIShowcase.WebApp.Components.ChatOutputServices
{
	public class PrismInterop(IJSRuntime js)
	{
		public async Task HighlightAll() => await js.InvokeVoidAsync("highlightAll");
		public async Task HighlightAllUnder(ElementReference element) => await js.InvokeVoidAsync("highlightAllUnder", element);
	}
}
