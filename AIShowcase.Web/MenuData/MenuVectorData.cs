using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using Microsoft.SemanticKernel.Connectors.InMemory;

namespace AIShowcase.WebApp.MenuData;

public class MenuVectorData(IEmbeddingGenerator<string, Embedding<float>> generator)
{
	private VectorStoreCollection<string, MenuItem>? vectors;
	public InMemoryVectorStore VectorStore { get; private set; } = new InMemoryVectorStore();

	public async Task CreateVectorDataSource(IList<MenuItem> data)
	{
		vectors = VectorStore.GetCollection<string, MenuItem>("menu");

		await vectors.EnsureCollectionExistsAsync();

		foreach (var item in data)
		{
			item.Vector = await generator.GenerateVectorAsync(item.Text);
			await vectors.UpsertAsync(item);
		}
	}

	public async Task<VectorSearchResult<MenuItem>?> Search(string query)
	{
		if (vectors is null) throw new InvalidOperationException("Use the CreateVectorDataSource method before searching.");
		ReadOnlyMemory<float> queryEmbedding = await generator.GenerateVectorAsync(query);
		var results = vectors.SearchAsync(queryEmbedding, top: 1);
		var item = await results.FirstOrDefaultAsync();
		return item;
	}
}