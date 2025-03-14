using Microsoft.Extensions.VectorData;
using Telerik.SvgIcons;

namespace AIShowcase.WebApp.Support
{
	public class MenuItem
	{

		[VectorStoreRecordKey]
		public required string Text { get; set; }
		
		public required ISvgIcon Icon { get; set; }

		[VectorStoreRecordData]
		public required string Url { get; set; }

		public bool Separator { get; set; }
		
		[VectorStoreRecordData]
		public required string Description { get; set; }

		[VectorStoreRecordVector(1536, DistanceFunction.CosineSimilarity)] // 1536 is the default vector size for the OpenAI text-embedding-3-small model
		public ReadOnlyMemory<float> Vector { get; set; }
	}
}
