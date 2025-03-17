using ElevenLabs.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;

namespace AIShowcase.WebApp.Components.Generic;
public class AudioPlayerInterop
{
	private readonly Lazy<Task<IJSObjectReference>> moduleTask;

	[AllowNull]
	IJSObjectReference module;

	private const string ModulePath = "./audioplayer-interop.js";
	public AudioPlayerInterop(IJSRuntime jsRuntime)
	{
		moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
		"import", $"{ModulePath}").AsTask());
	}

	public async Task InitializeAsync(ElementReference audioTagRef, string? targetVisualizer)
	{
		module = await moduleTask.Value;
		await module.InvokeVoidAsync("init", audioTagRef, targetVisualizer, DotNetObjectReference.Create(this));
	}

	public async Task AddVisualizer(string targetCanvas)
	{
		await module.InvokeVoidAsync("addVisualizer", targetCanvas);
	}

	public async Task Play()
	{
		await module.InvokeVoidAsync("play");
	}
	public async Task Pause()
	{
		await module.InvokeVoidAsync("pause");
	}
	public async Task Stop()
	{
		await module.InvokeVoidAsync("stop");
	}

	public async Task SetVolume(double volume)
	{
		await module.InvokeVoidAsync("setVolume", volume);
	}
	public async Task Load(string dataUri)
	{
		await module.InvokeVoidAsync("load", dataUri);
	}

	public async Task Mute(bool isMuted)
	{
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

