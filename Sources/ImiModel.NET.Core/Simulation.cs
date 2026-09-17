using ImiModel.NET.Core.Models.Abstracts.Commons.Nodes;
using ImiModel.NET.Core.Models.Abstracts.Nodes;
using ImiModel.NET.Core.Models.Base;
using ImiModel.NET.Logging.Models;

namespace ImiModel.NET.Core;

public abstract class Simulation
{
	protected readonly List<NodeBase> Nodes = [];
	protected readonly Dictionary<Guid, NodeBase> NodesById = new();

	protected MetricCollector Collector { get; set; } = null!;
	protected SimulationContext Context { get; set; } = null!;

	public void AddNodes(params NodeBase[] nodes)
	{
		foreach (var node in nodes)
		{
			if (!NodesById.TryAdd(node.Id, node))
				continue;

			Nodes.Add(node);
		}
	}

	protected internal void CompleteRequest(Request request)
	{
		if (NodesById.TryGetValue(request.SourceId, out var node) && node is SourceBase source)
			source.OnRequestCompleted();
	}

	public abstract void Simulate();
}