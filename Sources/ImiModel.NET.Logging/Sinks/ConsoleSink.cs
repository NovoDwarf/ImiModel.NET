using ImiModel.NET.Logging.Interfaces;
using ImiModel.NET.Logging.Models;

namespace ImiModel.NET.Logging.Sinks;

public class ConsoleSink : IMetricSink
{
	public void Flush(Report report)
	{
		Console.WriteLine(report);
	}
}