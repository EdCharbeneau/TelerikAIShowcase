using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using Microsoft.SemanticKernel.Connectors.InMemory;

namespace AIShowcase.WebApp.MenuData;

public class MenuVectorData(IEmbeddingGenerator<string, Embedding<float>> generator)
{
	private IVectorStoreRecordCollection<string, MenuItem>? vectors;
	public InMemoryVectorStore VectorStore { get; private set; } = new InMemoryVectorStore();

	public async Task CreateVectorDataSource(IList<MenuItem> data)
	{
		vectors = VectorStore.GetCollection<string, MenuItem>("menu");

		await vectors.CreateCollectionIfNotExistsAsync();

		foreach (var item in data)
		{
			item.Vector = await generator.GenerateEmbeddingVectorAsync(item.Text);
			await vectors.UpsertAsync(item);
		}
	}

	public async Task<VectorSearchResults<MenuItem>> Search(string query)
	{
		if (vectors is null) throw new InvalidOperationException("Use the CreateVectorDataSource method before searching.");
		var queryEmbedding = await generator.GenerateEmbeddingVectorAsync(query);
		var searchOptions = new VectorSearchOptions<MenuItem>()
		{
			Top = 1,
		};

		VectorSearchResults<MenuItem> results = await vectors.VectorizedSearchAsync(queryEmbedding, searchOptions);

		return results;

	}
}