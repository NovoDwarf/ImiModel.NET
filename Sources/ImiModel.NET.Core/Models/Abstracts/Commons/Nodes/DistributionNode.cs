using ImiModel.NET.Core.Models.Abstracts.Commons.Options;
using MathForge.Core.Base.Entities;

namespace ImiModel.NET.Core.Models.Abstracts.Commons.Nodes;

public abstract class DistributionNode : RouteNode
{
	private readonly DistributionOptions _options;

	public DistributionNode(DistributionOptions? options = null) : base(options)
	{
		_options = options ?? new DistributionOptions();
	}

	public bool IsBusy { get; protected set; }
	public Distribution Distribution => _options.Distribution;
}