using Microsoft.Extensions.VectorData;
using Telerik.SvgIcons;

namespace AIShowcase.WebApp.MenuData;

public class MenuItem
{
	[VectorStoreKey]
	public required string Text { get; set; }

	public required ISvgIcon Icon { get; set; }

	[VectorStoreData]
	public required string Url { get; set; }

	public bool Separator { get; set; }

	[VectorStoreData]
	public required string Description { get; set; }

	[VectorStoreVector(1536, DistanceFunction = DistanceFunction.CosineSimilarity)]
	public ReadOnlyMemory<float> Vector { get; set; }
}