using AIShowcase.WebApp.Components.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.AI;
using Telerik.Blazor.Components;

namespace AIShowcase.WebApp.Components.Pages.Chat;
public partial class ChatInput
{
	TelerikFileSelect? UploadRef;

	[Parameter]
	public EventCallback<ChatMessage> OnSend { get; set; }

	[Parameter]
	public EventCallback<ChatMessage> OnSendSpeech { get; set; }

	[Parameter]
	public EventCallback<ChatMessage> OnSendImage { get; set; }

	[Parameter]
	public EventCallback OnMicrophoneStart { get; set; }

	[Parameter]
	public EventCallback OnRestartChatClicked { get; set; }

	private Task OnRecordClick(MouseEventArgs _) => OnMicrophoneStart.InvokeAsync();

	private string? messageText = "";

	private bool canSubmit => !string.IsNullOrWhiteSpace(messageText);

	private async Task SendMessageAsync()
	{
		var message = new ChatMessage(ChatRole.User, messageText);
		messageText = null;
		await OnSend.InvokeAsync(message);
	}
	async Task OnRecognizedText(string value)
	{
		await Microphone!.StopRecording();
		messageText = null;
		await OnSendSpeech.InvokeAsync(new ChatMessage(ChatRole.User, value));
	}

	async Task SubmitOnEnter(KeyboardEventArgs args)
	{
		if (args.Key == "Enter" && !args.ShiftKey && canSubmit)
		{
			await SendMessageAsync();
		}
	}

	#region Voice
	public bool isAudioPlaying;
	SpeechToTextButton? Microphone;
	public AudioPlayer? audioPlayer {  get; private set; }
	async Task OnStopAudio()
	{
		isAudioPlaying = false;
		await audioPlayer!.Stop();
	}
	public async Task PlaySpeech(string text)
	{
		if (settings.SelectedVoice is null || audioPlayer is null) return;
		string speech = await tts.GetSpeechAsBase64String(text, settings.SelectedVoice.Id);
		await audioPlayer.Load(speech);
		isAudioPlaying = true;
		await audioPlayer.Play();
	}
	async Task OnAudioEnded()
	{
		isAudioPlaying = false;
		if (Microphone is null) return;
		await Microphone.StartRecording();
	}

	#endregion

	#region Popup Menu
	private TelerikPopup? PopupRef;
	private bool popupVisible = false;

	private void TogglePopup()
	{
		if (popupVisible)
		{
			PopupRef?.Hide();
		}
		else
		{
			PopupRef?.Show();
		}
		popupVisible = !popupVisible;
	}

	async Task OnFileSelect(FileSelectEventArgs args)
	{
		messageText = null;
		PopupRef?.Hide();
		if (UploadRef is null) return;

		var file = args.Files[0];

		byte[]? imgBytes = null;

		// Fully flush out the uploaded file Stream into a MemoryStream then copy into the byte[]
		using var ms = new MemoryStream();
		await file.Stream.CopyToAsync(ms);
		imgBytes = ms.ToArray();

		ChatMessage imageMessage = new(ChatRole.User, "What's in this image?");
		imageMessage.Contents.Add(new DataContent(imgBytes, "image/jpg"));

		await OnSendImage.InvokeAsync(imageMessage);

	}

	private Task OnNewChatClicked()
	{
		messageText = null;
		PopupRef?.Hide();
		return OnRestartChatClicked.InvokeAsync();
	}


	#endregion
}
