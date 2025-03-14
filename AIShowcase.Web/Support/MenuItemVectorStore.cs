using Microsoft.Extensions.VectorData;

namespace AIShowcase.WebApp.Support
{
	public class MenuItemVectorStore : IVectorStore
	{
		public IVectorStoreRecordCollection<TKey, TRecord> GetCollection<TKey, TRecord>(string name, VectorStoreRecordDefinition? vectorStoreRecordDefinition = null) where TKey : notnull
		{
			return new MenuVectorStoreRecordCollection<TKey, TRecord>(name);
		}

		public IAsyncEnumerable<string> ListCollectionNamesAsync(CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		private class MenuVectorStoreRecordCollection<TKey, TRecord> : IVectorStoreRecordCollection<TKey, TRecord>
			where TKey : notnull
		{
			private string _name;
			private Dictionary<TKey, TRecord>? _records;
			public MenuVectorStoreRecordCollection(string name)
			{
				_name = name;
			}
			public string CollectionName => _name;

			public Task<bool> CollectionExistsAsync(CancellationToken cancellationToken = default)
			{
				throw new NotImplementedException();
			}

			public Task CreateCollectionAsync(CancellationToken cancellationToken = default)
			{
				_records = new();
				return Task.CompletedTask;
			}

			public Task CreateCollectionIfNotExistsAsync(CancellationToken cancellationToken = default)
			{
				if (_records == null)
				{
					_records = new();
				}
				return Task.CompletedTask;
			}

			public Task DeleteAsync(TKey key, CancellationToken cancellationToken = default)
			{
				throw new NotImplementedException();
			}

			public Task DeleteBatchAsync(IEnumerable<TKey> keys, CancellationToken cancellationToken = default)
			{
				throw new NotImplementedException();
			}

			public Task DeleteCollectionAsync(CancellationToken cancellationToken = default)
			{
				throw new NotImplementedException();
			}

			public Task<TRecord?> GetAsync(TKey key, GetRecordOptions? options = null, CancellationToken cancellationToken = default)
			{
				throw new NotImplementedException();
			}

			public IAsyncEnumerable<TRecord> GetBatchAsync(IEnumerable<TKey> keys, GetRecordOptions? options = null, CancellationToken cancellationToken = default)
			{
				throw new NotImplementedException();
			}

			public Task<TKey> UpsertAsync(TRecord record, CancellationToken cancellationToken = default)
			{
				throw new NotImplementedException();
			}

			public IAsyncEnumerable<TKey> UpsertBatchAsync(IEnumerable<TRecord> records, CancellationToken cancellationToken = default)
			{
				throw new NotImplementedException();
			}

			public Task<VectorSearchResults<TRecord>> VectorizedSearchAsync<TVector>(TVector vector, VectorSearchOptions<TRecord>? options = null, CancellationToken cancellationToken = default)
			{
				throw new NotImplementedException();
			}
		}
	}
}
