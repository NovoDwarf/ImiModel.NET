using ImiModel.NET.Logging.Models;

namespace ImiModel.NET.Logging.Interfaces;

public interface IMetricSink
{
	void Flush(Report report);
}