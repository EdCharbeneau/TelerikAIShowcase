using ai_demos.Services.Ingestion;
using ai_demos.Services;
using Microsoft.Extensions.VectorData;
using Microsoft.EntityFrameworkCore;

namespace AIShowcase.WebApp.Services
{
	public static class DocumentSearchServiceExtensions
	{
		public static void AddDocumentSearchServices(this WebApplicationBuilder builder)
		{

			var vectorStore = new JsonVectorStore(Path.Combine(AppContext.BaseDirectory, "vector-store"));

			builder.Services.AddSingleton<IVectorStore>(vectorStore);
			builder.Services.AddScoped<DataIngestor>();
			builder.Services.AddSingleton<SemanticSearch>();

			builder.Services.AddDbContext<IngestionCacheDbContext>(options =>
				options.UseSqlite("Data Source=ingestioncache.db"));
		}
	}
}
