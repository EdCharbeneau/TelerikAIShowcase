using Telerik.Blazor;
using Telerik.SvgIcons;

namespace AIShowcase.WebApp.Components.Layout.Main
{
	public class DrawerItemModel
	{
		public string Text { get; set; }
		public ISvgIcon Icon { get; set; }
		public string Url { get; set; }
		public bool Separator { get; set; }
	}
}
