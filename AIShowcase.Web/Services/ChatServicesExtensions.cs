using AIShowcase.WebApp.Components.Pages.Chat;
using Azure;
using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;

namespace AIShowcase.WebApp.Services
{
	public static class ChatServicesExtensions
	{
		public static void AddChatServices(this WebApplicationBuilder builder)
		{
			//Authentication with Azure OpenAI
			AzureOpenAIClient innerClient =
				new AzureOpenAIClient(
					new Uri(builder.Configuration["Chat:AzureOpenAI:Endpoint"] ??
						throw new InvalidOperationException("The required AzureOpenAI endpoint was not configured for this application.")),
					new AzureKeyCredential(builder.Configuration["Chat:AzureOpenAI:Key"] ??
						throw new InvalidOperationException("The required AzureOpenAI Key was not configured for this application."))
				);

			//builder.AddOllamaApiClient("connectionName").AddChatClient();

			builder.Services.AddSingleton(innerClient);

			var client = innerClient.AsChatClient("gpt-4o-mini");
			builder.Services.AddChatClient(client).UseFunctionInvocation();
			
			var embedding = innerClient.AsEmbeddingGenerator("text-embedding-3-small");
			builder.Services.AddEmbeddingGenerator(embedding);

			builder.Services.AddScoped<NavigationTool>();
			builder.Services.AddScoped<VoiceSettingsTool>();
		}

	}
}
