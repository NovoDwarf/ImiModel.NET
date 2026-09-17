using MathForge.Core.Base.Entities;
using MathForge.Probability.Distributions.Univariate.Continuous.Semibounded;

namespace ImiModel.NET.Core.Models.Abstracts.Commons.Options;

public class DistributionOptions : RouteOptions
{
	public Distribution Distribution { get; set; } = new ExpoDistribution() ;
}