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
			new DrawerItemModel() { Text = "Dashboard", Icon = SvgIcon.Star },
			//new DrawerItemModel() { Text = "Statistics", Icon = SvgIcon.ChartColumnStacked },
			//new DrawerItemModel() { Text = "Reports", Icon = SvgIcon.FileTxt },
			//new DrawerItemModel() { Separator = true },
			//new DrawerItemModel() { Text = "Settings", Icon = SvgIcon.Gear },
			//new DrawerItemModel() { Text = "Support", Icon = SvgIcon.QuestionCircle }
		};

	private async Task ToggleDrawer() => await DrawerRef.ToggleAsync();

	#endregion Drawer Data

}
