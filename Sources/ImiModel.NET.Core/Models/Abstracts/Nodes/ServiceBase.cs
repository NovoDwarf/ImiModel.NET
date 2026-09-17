using ImiModel.NET.Core.Models.Abstracts.Commons.Nodes;
using ImiModel.NET.Core.Models.Abstracts.Options;

namespace ImiModel.NET.Core.Models.Abstracts.Nodes;

public abstract class ServiceBase : DistributionNode
{
	protected ServiceBase(ServiceOptions? options = null) : base(options)
	{
	}
}