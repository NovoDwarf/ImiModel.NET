using ImiModel.NET.Core.Models.Abstracts.Commons.Nodes;
using ImiModel.NET.Core.Models.Abstracts.Options;

namespace ImiModel.NET.Core.Models.Abstracts.Nodes;

public abstract class SinkBase : RouteNode
{
	protected SinkBase(SinkOptions? options = null) : base(options)
	{
	}
}