using ElevenLabs.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace AIShowcase.WebApp.Components.Generic;
public class AudioPlayerInterop
{
	private readonly Lazy<Task<IJSObjectReference>> moduleTask;

	private const string ModulePath = "./audioplayer-interop.js";
	public AudioPlayerInterop(IJSRuntime jsRuntime)
	{
		moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
		"import", $"{ModulePath}").AsTask());
	}

	public async Task InitializeAsync(ElementReference audioTagRef)
	{
		var module = await moduleTask.Value;
		await module.InvokeVoidAsync("init", audioTagRef, DotNetObjectReference.Create(this));
	}

	public async Task Play()
	{
		var module = await moduleTask.Value;
		await module.InvokeVoidAsync("play");
	}
	public async Task Pause()
	{
		var module = await moduleTask.Value;
		await module.InvokeVoidAsync("pause");
	}
	public async Task Stop()
	{
		var module = await moduleTask.Value;
		await module.InvokeVoidAsync("stop");
	}

	public async Task SetVolume(double volume)
	{
		var module = await moduleTask.Value;
		await module.InvokeVoidAsync("setVolume", volume);
	}
	public async Task Load(string dataUri)
	{
		var module = await moduleTask.Value;
		await module.InvokeVoidAsync("load", dataUri);
	}

	public async Task Mute(bool isMuted)
	{
		var module = await moduleTask.Value;
		await module.InvokeVoidAsync("mute", isMuted);
	}

	public event Action? OnSourceChanged;

	[JSInvokable]
	public Task OnSourceChangedHandler()
	{
		OnSourceChanged?.Invoke();
		return Task.CompletedTask;
	}
}
