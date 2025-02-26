using Telerik.Blazor.Components;
using Telerik.SvgIcons;

namespace AIShowcase.WebApp.Components.Layout.Main;
public partial class MainLayout
{
	private DrawerItemModel _selectedDrawerItem;

	#region Drawer Data

	private bool DrawerExpanded { get; set; } = true;

	private TelerikDrawer<DrawerItemModel> DrawerRef { get; set; }

	private DrawerItemModel SelectedDrawerItem
	{
		get => _selectedDrawerItem ?? DrawerItems.FirstOrDefault();
		set => _selectedDrawerItem = value;
	}

	private IEnumerable<DrawerItemModel> DrawerItems { get; set; } = new List<DrawerItemModel>()
		{
			new DrawerItemModel() { Text = "Dashboard", Icon = SvgIcon.Star, Url = "/" },
			new DrawerItemModel() { Text = "Voice Input", Icon = SvgIcon.RadiobuttonChecked, Url = "/speech-to-text" },
			new DrawerItemModel() { Text = "Voice Output", Icon = SvgIcon.VolumeUp, Url = "/text-to-speech" },
			//new DrawerItemModel() { Separator = true },
			//new DrawerItemModel() { Text = "Settings", Icon = SvgIcon.Gear },
			//new DrawerItemModel() { Text = "Support", Icon = SvgIcon.QuestionCircle }
		};

	private async Task ToggleDrawer() => await DrawerRef.ToggleAsync();

	#endregion Drawer Data

}
