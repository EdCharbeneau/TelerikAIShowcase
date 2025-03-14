using Telerik.SvgIcons;

namespace AIShowcase.WebApp.Support
{
	public class MainMenu
	{
		public MainMenu()
		{
			Items.Add(new MenuItem()
			{
				Text = "Home",
				Icon = SvgIcon.Star,
				Url = "/",
				Description = "The main dashboard"
			});
			Items.Add(new MenuItem()
			{
				Text = "Voice Input",
				Icon = SvgIcon.RadiobuttonChecked,
				Url = "/speech-to-text",
				Description = "Convert voice input to text output"
			});
			Items.Add(new MenuItem()
			{
				Text = "Voice Output",
				Icon = SvgIcon.VolumeUp,
				Url = "/text-to-speech",
				Description = "Convert text input to voice output"
			});
			Items.Add(new MenuItem()
			{
				Text = "Basic Chat",
				Icon = SvgIcon.Textbox,
				Url = "/basic-chat",
				Description = "A basic chat interface"
			});

		}
		public List<MenuItem> Items { get; set; } = [];

	}
}
