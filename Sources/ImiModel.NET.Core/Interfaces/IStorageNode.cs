using ImiModel.NET.Core.Models.Base;

namespace ImiModel.NET.Core.Interfaces;

public interface IStorageNode : INode
{
	public bool IsUnlimitedCapacity { get; }
	
	public bool IsFull { get; }

	public int Count { get; }
	
	public int Capacity { get; }

	public Request? Dequeue();

	public void Enqueue(Request request);

	public Request? Peek();
}