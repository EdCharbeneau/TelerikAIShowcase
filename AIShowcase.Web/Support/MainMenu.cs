using Telerik.SvgIcons;

namespace AIShowcase.WebApp.Support
{
	public class MainMenu
	{
		public MainMenu()
		{
			Items.Add(new MenuItem()
			{
				DisplayName = "Home",
				Icon = SvgIcon.Star,
				Url = "/",
				Description = "The main dashboard"
			});
			Items.Add(new MenuItem()
			{
				DisplayName = "Voice Input",
				Icon = SvgIcon.RadiobuttonChecked,
				Url = "/speech-to-text",
				Description = "Convert speech to text"
			});
			Items.Add(new MenuItem()
			{
				DisplayName = "Voice Output",
				Icon = SvgIcon.VolumeUp,
				Url = "/text-to-speech",
				Description = "Convert text to speech"
			});
			Items.Add(new MenuItem()
			{
				DisplayName = "Basic Chat",
				Icon = SvgIcon.Textbox,
				Url = "/basic-chat",
				Description = "A basic chat interface"
			});

		}
		public List<MenuItem> Items { get; set; } = [];

	}
}
