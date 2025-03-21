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
			//builder.AddOllamaApiClient("llama32").AddChatClient().UseFunctionInvocation().UseLogging();
			builder.AddOllamaApiClient("local-embedding").AddEmbeddingGenerator();

			// Authentication with Azure OpenAI
			//AzureOpenAIClient innerClient =
			//		new Uri(builder.Configuration["Chat:AzureOpenAI:Endpoint"] ??
			//	new AzureOpenAIClient(
			//			throw new InvalidOperationException("The required AzureOpenAI endpoint was not configured for this application.")),
			//		new AzureKeyCredential(builder.Configuration["Chat:AzureOpenAI:Key"] ??
			//			throw new InvalidOperationException("The required AzureOpenAI Key was not configured for this application."))
			//	);

			#region GitHub Models
			var credential = new ApiKeyCredential(builder.Configuration["Chat:GitHubModels:Token"] ?? throw new InvalidOperationException("Missing configuration: GitHubModels:Token. See the README for details."));
			var openAIOptions = new OpenAIClientOptions()
			{
				Endpoint = new Uri("https://models.inference.ai.azure.com")
			};

			var innerClient = new OpenAIClient(credential, openAIOptions);
			builder.Services.AddSingleton(innerClient);

			var client = innerClient.AsChatClient("gpt-4o-mini");
			builder.Services.AddChatClient(client).UseFunctionInvocation().UseLogging();

			//var embedding = innerClient.AsEmbeddingGenerator("text-embedding-3-small");
			//builder.Services.AddEmbeddingGenerator(embedding);
			#endregion

			builder.Services.AddScoped<NavigationTool>();
			builder.Services.AddScoped<VoiceSettingsTool>();
		}

	}
}
