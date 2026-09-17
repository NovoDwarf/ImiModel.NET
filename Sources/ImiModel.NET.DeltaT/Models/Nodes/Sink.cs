using System.Diagnostics;
using ImiModel.NET.Core.Models.Abstracts.Nodes;
using ImiModel.NET.Core.Models.Abstracts.Options;
using ImiModel.NET.Core.Models.Base;

namespace ImiModel.NET.DeltaT.Models.Nodes;

[DebuggerDisplay("Sink [{Id}]")]
public class Sink : SinkBase
{
	public Sink(SinkOptions? options = null) : base(options)
	{
	}

	public override void Process(Request request)
	{
		Context.Collector.CounterIncrement($"{Id}_Sink_Completed");
	}
}