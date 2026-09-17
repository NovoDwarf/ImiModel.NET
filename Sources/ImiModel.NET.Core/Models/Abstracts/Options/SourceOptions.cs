using ImiModel.NET.Core.Models.Abstracts.Commons.Options;

namespace ImiModel.NET.Core.Models.Abstracts.Options;

public class SourceOptions : DistributionOptions
{
	public bool ClosedSystem { get; set; } = false;
	public int ClosedPopulation { get; set; } = 1;
}