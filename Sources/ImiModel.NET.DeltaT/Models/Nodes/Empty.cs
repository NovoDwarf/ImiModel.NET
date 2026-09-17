using ImiModel.NET.Core.Models.Abstracts.Nodes;
using ImiModel.NET.Core.Models.Abstracts.Options;

namespace ImiModel.NET.DeltaT.Models.Nodes;

public sealed class Empty : EmptyBase
{
	public Empty(EmptyOptions? options = null) : base(options) { }
}