using System.Collections.Concurrent;
using ImiModel.NET.Logging.Interfaces;

namespace ImiModel.NET.Logging.Models.Storages;

public class InMemoryStorage : IMetricStorage
{
	private readonly ConcurrentDictionary<string, IMetricEvent> _metrics = new();

	public void Store(IMetricEvent metric)
	{
		var key = $"{metric.Type}:{metric.Name}";

		_metrics.AddOrUpdate(
			key,
			metric,
			(_, existing) => existing.MergeWith(metric)
		);
	}

	public IReadOnlyCollection<IMetricEvent> GetAll()
	{
		return _metrics.Values.ToList();
	}

	public void Clear()
	{
		_metrics.Clear();
	}
}