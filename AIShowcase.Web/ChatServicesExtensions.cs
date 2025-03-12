using Azure;
using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;

namespace AIShowcase.WebApp
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

			builder.Services.AddSingleton(innerClient);

			IChatClient client = innerClient.AsChatClient("gpt-4o-mini");

			builder.Services.AddChatClient(services => services.GetRequiredService<AzureOpenAIClient>()
				.AsChatClient(builder.Configuration["Chat:AzureOpenAI:ModelId"] ?? "gpt-4o-mini"));

		}

	}
}
