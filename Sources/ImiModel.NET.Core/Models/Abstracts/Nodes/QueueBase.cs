using ImiModel.NET.Core.Models.Abstracts.Commons.Nodes;
using ImiModel.NET.Core.Models.Abstracts.Options;

namespace ImiModel.NET.Core.Models.Abstracts.Nodes;

public abstract class QueueBase : RouteNode
{
	private protected readonly QueueOptions _options;

	protected QueueBase(QueueOptions? options = null) : base(options)
	{
		_options = options ?? new QueueOptions();
	}
}