using ImiModel.NET.Core.Models.Abstracts.Commons.Nodes;
using ImiModel.NET.Core.Models.Abstracts.Options;

namespace ImiModel.NET.Core.Models.Abstracts.Nodes;

public abstract class EmptyBase : RouteNode
{
	protected EmptyBase(EmptyOptions? options = null) : base(options)
	{
	}
}