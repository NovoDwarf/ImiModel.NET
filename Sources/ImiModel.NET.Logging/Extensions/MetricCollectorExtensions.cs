using ImiModel.NET.Logging.Models;
using ImiModel.NET.Logging.Sinks;

namespace ImiModel.NET.Logging.Extensions;

public static class MetricCollectorExtensions
{
	extension(MetricCollector collector)
	{
		public void WithConsole()
		{
			var sink = new ConsoleSink();

			collector.AddSink(sink);
		}
	}
}