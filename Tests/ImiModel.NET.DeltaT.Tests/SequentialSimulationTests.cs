using ImiModel.NET.Core.Extensions;
using ImiModel.NET.Core.Models.Abstracts.Options;
using ImiModel.NET.DeltaT.Models.Nodes;
using ImiModel.NET.DeltaT.Models.Simulations;
using MathForge.Probability.Distributions.Degenerate;

namespace ImiModel.NET.DeltaT.Tests;

public class SequentialSimulationTests
{
	[Fact]
	public void Simulate_ConstantDistribution_ProcessesRequests()
	{
		// Arrange
		var sim = new SequentialSimulation();

		var sourceDistribution = new DegenerateDistribution();
		sourceDistribution.Set(10);

		var serviceDistribution = new DegenerateDistribution();
		serviceDistribution.Set(20);

		var source = new Source(new SourceOptions
		{
			Distribution = sourceDistribution,
			ClosedSystem = true,
			ClosedPopulation = 1
		});

		var queue = new Queue();

		var service = new Service(new ServiceOptions { Distribution = serviceDistribution });

		var sink = new Sink();

		source
			.Connect(queue)
			.Connect(service)
			.Connect(sink);

		sim.AddNodes(source, queue, service, sink);

		// Act
		sim.Simulate();

		// Assert
		Assert.Equal(0, queue.Count);
	}
}