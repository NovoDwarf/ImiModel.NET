# ImiModel.NET

> [!WARNING]
> This project was created for educational purposes and is still under development. It may contain bugs, incomplete features, and architectural flaws. The code is not production-ready and should be used with caution.

A .NET framework for building and running discrete-event and time-stepped simulation models.

ImiModel.NET provides a modular approach to simulation modeling, allowing developers to construct systems from interconnected nodes such as sources, queues, services, and sinks. The framework supports multiple simulation methods while sharing common entities, options, and logging infrastructure.

## Features

- Modular simulation architecture — build models from reusable simulation nodes.
- Multiple simulation methods — time-stepped (Δt) and event-driven simulation.
- Node-based modeling — connect sources, queues, services, and sinks into simulation networks.
- Probability distributions — use distributions from the MathForge ecosystem.
- Shared infrastructure — common entities, options, and logging support.
- Extensible design — create and extend simulation models using C# and .NET.

## Packages

The framework is divided into four NuGet packages:

| Package | Description |
| --- | --- |
| ImiModel.NET.Core | Core library containing shared entities, abstractions, models, and common functionality. |
| ImiModel.NET.DeltaT | Time-stepped simulation method based on a fixed or configurable time increment Δt. |
| ImiModel.NET.EventDriven | Event-driven simulation method based on processing scheduled simulation events. |
| ImiModel.NET.Logging | Shared logging library for simulation models and runtime components. |

## How It Works

A simulation model is built as a network of interconnected nodes. Each node represents a component of the modeled system and performs a specific function.

Typical simulation components include:

- Source — generates entities entering the system.
- Queue — stores entities waiting for service.
- Service — processes entities according to a service-time distribution.
- Sink — receives entities leaving the system.

Nodes are connected to define the flow of entities through the model. The resulting network can then be executed using the selected simulation method.

## Event-Driven Simulation

The event-driven method processes scheduled simulation events. In this example, four sources generate entities that enter a shared queue, pass through two service stations, and finally reach the sink.

```csharp
using ImiModel.NET.Core.Models.Abstracts.Options;
using ImiModel.NET.EventDriven.Models.Nodes;
using ImiModel.NET.EventDriven.Models.Simulations;
using MathForge.Probability.Distributions.Univariate.Continuous.Semibounded;

internal static class Program
{
    public static void Main(string[] args)
    {
        StartConsoleSim();
    }

    private static void StartConsoleSim()
    {
        var sim = new EventDrivenSimulation();

        var sourceExpo = new ExpoDistribution();
        var serviceExpo = new ExpoDistribution();

        sourceExpo.Set(10);
        serviceExpo.Set(200);

        var collector = sim.EventCollector;

        var g1 = new Source(new SourceOptions
        {
            Distribution = sourceExpo
        });

        var g2 = new Source(new SourceOptions
        {
            Distribution = sourceExpo
        });

        var g3 = new Source(new SourceOptions
        {
            Distribution = sourceExpo
        });

        var g4 = new Source(new SourceOptions
        {
            Distribution = sourceExpo
        });

        var q1 = new Queue();
        var q2 = new Queue();

        var u1 = new Service(
            collector,
            new ServiceOptions
            {
                Distribution = serviceExpo
            });

        var u2 = new Service(
            collector,
            new ServiceOptions
            {
                Distribution = serviceExpo
            });

        var s1 = new Sink();

        g1.Connect(q1);
        g2.Connect(q1);
        g3.Connect(q1);
        g4.Connect(q1);

        q1.Connect(u1)
          .Connect(q2)
          .Connect(u2)
          .Connect(s1);

        sim.AddNodes(
            g1, g2, g3, g4,
            q1, q2,
            u1, u2,
            s1);

        sim.Simulate();
    }
}
```

## Time-Stepped Simulation (Δt)

The Δt method advances the simulation in discrete time increments. In this example, each source is configured as a closed system with a closed population of one.

```csharp
using ImiModel.NET.Core.Extensions;
using ImiModel.NET.Core.Models.Abstracts.Options;
using ImiModel.NET.DeltaT.Models.Nodes;
using ImiModel.NET.DeltaT.Models.Simulations;
using MathForge.Probability.Distributions.Univariate.Continuous.Semibounded;

namespace ImiModel.NET.DeltaT.Example;

internal static class Program
{
    public static void Main(string[] args)
    {
        StartConsoleSim();
    }

    private static void StartConsoleSim()
    {
        var sim = new SequentialSimulation();

        var sourceExpo = new ExpoDistribution();
        var serviceExpo = new ExpoDistribution();

        sourceExpo.Set(10);
        serviceExpo.Set(200);

        var g1 = new Source(new SourceOptions
        {
            Distribution = sourceExpo,
            ClosedSystem = true,
            ClosedPopulation = 1
        });

        var g2 = new Source(new SourceOptions
        {
            Distribution = sourceExpo,
            ClosedSystem = true,
            ClosedPopulation = 1
        });

        var g3 = new Source(new SourceOptions
        {
            Distribution = sourceExpo,
            ClosedSystem = true,
            ClosedPopulation = 1
        });

        var g4 = new Source(new SourceOptions
        {
            Distribution = sourceExpo,
            ClosedSystem = true,
            ClosedPopulation = 1
        });

        var q1 = new Queue();
        var q2 = new Queue();

        var u1 = new Service(new ServiceOptions
        {
            Distribution = serviceExpo
        });

        var u2 = new Service(new ServiceOptions
        {
            Distribution = serviceExpo
        });

        var s1 = new Sink();

        g1.Connect(q1);
        g2.Connect(q1);
        g3.Connect(q1);
        g4.Connect(q1);

        q1.Connect(u1)
          .Connect(q2)
          .Connect(u2)
          .Connect(s1);

        sim.AddNodes(
            g1, g2, g3, g4,
            q1, q2,
            u1, u2,
            s1);

        sim.Simulate();
    }
}
```

## Related Libraries

ImiModel.NET uses supporting libraries from the NovoDwarf ecosystem.

### MathForge

[MathForge](https://github.com/NovoDwarf/MathForge/) is a mathematical library used by ImiModel.NET for mathematical and probability-related functionality.

### NovoDwarf.Projects

[NovoDwarf.Projects](https://github.com/NovoDwarf/NovoDwarf.Projects/) is a collection of supporting libraries and shared infrastructure used across NovoDwarf projects.

## Getting Started

1. Install the required ImiModel.NET packages.
2. Create a simulation instance using the desired simulation method.
3. Configure probability distributions and node options.
4. Create and connect simulation nodes.
5. Add the nodes to the simulation.
6. Run the simulation.

## License

[**ImiModel.NET**](https://github.com/NovoDwarf/ImiModel.NET/) is licensed under the [**MIT License**](), see [LICENSE](/LICENSE) for more information.