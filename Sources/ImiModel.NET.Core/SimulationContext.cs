using ImiModel.NET.Core.Models.Base;
using ImiModel.NET.Logging.Models;

namespace ImiModel.NET.Core;

public class SimulationContext
{
	public SimulationContext(MetricCollector metricCollector)
	{
		Collector = metricCollector;
	}

	public MetricCollector Collector { get; }

	public double CurrentTime { get; set; }
	public double TotalTime { get; set; } = 100;

	public int Ticks { get; private set; }

	public Random Random { get; } = new();

	public bool IsRunning => CurrentTime < TotalTime;
	
	public Action<Request>? CompleteRequest { get; set; }

	public void Tick(double deltaTime)
	{
		CurrentTime += deltaTime;
		Ticks++;
	}
}