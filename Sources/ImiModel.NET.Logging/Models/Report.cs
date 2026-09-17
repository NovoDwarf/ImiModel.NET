using ImiModel.NET.Logging.Interfaces;

namespace ImiModel.NET.Logging.Models;

public class Report
{
	public IReadOnlyCollection<IMetricEvent> Metrics;

	public Report(IReadOnlyCollection<IMetricEvent> metrics, DateTime dt)
	{
		Metrics = metrics;
	}
}