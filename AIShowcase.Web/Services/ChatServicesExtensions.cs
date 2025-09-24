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
			// 🌐 The Uri of your provider
			var endpoint = builder.Configuration["Chat:AzureOpenAI:Endpoint"] ?? throw new InvalidOperationException("Missing configuration: Endpoint. See the README for details.");
			// 🔑 The API Key for your provider
			var apikey = builder.Configuration["Chat:AzureOpenAI:Key"] ?? throw new InvalidOperationException("Missing configuration: ApiKey. See the README for details.");
			// 🧠 The model name or azure deployment name
			var model = "gpt-4o-mini";
			// Authentication with Azure OpenAI
			var azureOpenAi = new AzureOpenAIClient(
					new Uri(endpoint),
					new AzureKeyCredential(apikey)
				);

			#region GitHub Models
			//var credential = new ApiKeyCredential(builder.Configuration["Chat:GitHubModels:Token"] ?? throw new InvalidOperationException("Missing configuration: GitHubModels:Token. See the README for details."));
			//var openAIOptions = new OpenAIClientOptions()
			//{
			//	Endpoint = new Uri("https://models.inference.ai.azure.com")
			//};

			//var innerClient = new OpenAIClient(credential, openAIOptions);
			//builder.Services.AddSingleton(innerClient);

			var client = azureOpenAi.GetChatClient(model)
									.AsIChatClient();

			builder.Services.AddChatClient(client).UseFunctionInvocation().UseLogging();

			//var embedding = innerClient.AsEmbeddingGenerator("text-embedding-3-small");
			//builder.Services.AddEmbeddingGenerator(embedding);
			#endregion

			builder.Services.AddScoped<NavigationTool>();
			builder.Services.AddScoped<VoiceSettingsTool>();
		}

	}
}
