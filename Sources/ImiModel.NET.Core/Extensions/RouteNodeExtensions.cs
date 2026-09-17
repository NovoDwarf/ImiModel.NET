using ImiModel.NET.Core.Models.Abstracts.Commons.Nodes;

namespace ImiModel.NET.Core.Extensions;

public static class RouteNodeExtensions
{
	extension(RouteNode node)
	{
		public RouteNode Connect(RouteNode next)
		{
			node.AddOutput(next);

			return next;
		}
	}
}