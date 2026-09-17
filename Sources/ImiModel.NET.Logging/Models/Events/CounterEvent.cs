using ImiModel.NET.Logging.Interfaces;
using ImiModel.NET.Logging.Models.Base;

namespace ImiModel.NET.Logging.Models.Events;

public sealed class CounterEvent : BaseMetricEvent
{
	public override string Type => "counter";
	public double Value { get; private set; }

	public CounterEvent Increment(double value = 1)
	{
		Value += value;
		UpdateTimestamp();
		return this;
	}

	public override void Reset()
	{
		Value = 0;
	}

	public override IMetricEvent MergeWith(IMetricEvent other)
	{
		if (!CanMergeWith(other)) return this;
		Value += ((CounterEvent)other).Value;
		UpdateTimestamp();
		return this;
	}
}