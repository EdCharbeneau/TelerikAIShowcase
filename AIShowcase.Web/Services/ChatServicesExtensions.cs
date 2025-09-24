using AIShowcase.WebApp.Components.Pages.Chat;
using Azure;
using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using OpenAI;
using System.ClientModel;

namespace AIShowcase.WebApp.Services
{
	public static class ChatServicesExtensions
	{
		public static void AddChatServices(this WebApplicationBuilder builder)
		{
			// 🌐 The Uri of your provider
			var endpoint = builder.Configuration["Chat:AzureOpenAI:Endpoint"] ?? throw new InvalidOperationException("Missing configuration: Endpoint. See the README for details.");
			// 🔑 The API Key for your provider
			var apikey = builder.Configuration["Chat:AzureOpenAI:Key"] ?? throw new InvalidOperationException("Missing configuration: ApiKey. See the README for details.");
			// 🧠 The model name or azure deployment name
			var model = "gpt-4o-mini";

			// Replace the innerClient below with your preferred model provider 
			var innerClient = new OpenAIClient(
				new ApiKeyCredential(apikey),
				new OpenAIClientOptions()
				{
					Endpoint = new Uri(endpoint)
				}
				);

			builder.Services.AddChatClient(innerClient.AsChatClient(model)) // 🤖 Add the configured chat client
				.UseFunctionInvocation() // 🛠️ Include tool calling
				.UseLogging(); //🐞 Include Logging

			var embedding = innerClient.AsEmbeddingGenerator("text-embedding-3-small");
			builder.Services.AddEmbeddingGenerator(embedding);

			builder.Services.AddScoped<NavigationTool>();
			builder.Services.AddScoped<VoiceSettingsTool>();
			builder.Services.AddScoped<SynthaTool>();
		}

	}
}
