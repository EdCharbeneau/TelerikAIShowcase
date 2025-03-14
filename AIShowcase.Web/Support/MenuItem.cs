using Telerik.SvgIcons;

namespace AIShowcase.WebApp.Support
{
	public class MenuItem
	{

		public required string DisplayName { get; set; }
		public required ISvgIcon Icon { get; set; }
		public required string Url { get; set; }
		public bool Separator { get; set; }
		public required string Description { get; set; }
	}
}
