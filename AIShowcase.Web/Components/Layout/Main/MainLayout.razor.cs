using AIShowcase.WebApp.MenuData;
using System.Diagnostics.CodeAnalysis;
using Telerik.Blazor.Components;

namespace AIShowcase.WebApp.Components.Layout.Main;
public partial class MainLayout
{
	[AllowNull]
	private MenuItem _selectedDrawerItem;

	private MainMenu menu = new();

	#region Drawer Data

	private bool DrawerExpanded { get; set; } = true;

	private TelerikDrawer<MenuItem>? DrawerRef { get; set; }

	private MenuItem SelectedDrawerItem
	{
		get => _selectedDrawerItem ?? menu.Items.First();
		set => _selectedDrawerItem = value;
	}

	private async Task ToggleDrawer() => await DrawerRef!.ToggleAsync();

	#endregion Drawer Data

}
