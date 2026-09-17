using ImiModel.NET.Core.Interfaces;
using ImiModel.NET.Core.Models.Abstracts.Commons.Options;
using ImiModel.NET.Core.Models.Base;

namespace ImiModel.NET.Core.Models.Abstracts.Commons.Nodes;

/// <summary>
///     Base class for all nodes.
/// </summary>
public abstract class NodeBase : INode
{
	private readonly NodeOptions _options;

	protected NodeBase(NodeOptions? options = null)
	{
		_options = options ?? new NodeOptions();
	}

	protected SimulationContext Context { get; set; } = null!;

	/// <inheritdoc cref="INode.Id" />
	public Guid Id { get; } = Guid.NewGuid();

	public void SetContext(SimulationContext context)
	{
		Context = context;

		OnContextSet();
	}

	public abstract void Process(Request request);

	public abstract void Update(double deltaTime);

	public virtual void OnContextSet()
	{
	}
}