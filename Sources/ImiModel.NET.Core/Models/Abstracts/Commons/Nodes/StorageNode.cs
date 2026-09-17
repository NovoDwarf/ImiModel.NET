using ImiModel.NET.Core.Interfaces;
using ImiModel.NET.Core.Models.Abstracts.Commons.Options;
using ImiModel.NET.Core.Models.Base;

namespace ImiModel.NET.Core.Models.Abstracts.Commons.Nodes;

public abstract class StorageNode : NodeBase, IStorageNode
{
	private readonly StorageOptions _options;

	protected StorageNode(StorageOptions? options = null) : base(options)
	{
		_options = options ?? new StorageOptions();
	}

	/// <inheritdoc cref="IStorageNode.IsEmpty" />
	public bool IsEmpty => Storage.Count == 0;

	public int Count => Storage.Count;
	
	/// <inheritdoc cref="IStorageNode.Storage" />
	protected IStorage<Request> Storage => _options.Storage;

	/// <inheritdoc cref="IStorageNode.IsUnlimitedCapacity" />
	public bool IsUnlimitedCapacity => Capacity <= 0;

	/// <inheritdoc cref="IStorageNode.IsFull" />
	public bool IsFull => !IsUnlimitedCapacity && Storage.Count >= Capacity;

	/// <inheritdoc cref="IStorageNode.Capacity" />
	public int Capacity => _options.Capacity;

	public Request? Dequeue()
	{
		return IsEmpty ? null : Storage.Dequeue();
	}

	public void Enqueue(Request request)
	{
		if (IsFull)
			return;

		Storage.Enqueue(request);
	}

	public Request? Peek()
	{
		return Storage.Peek();
	}
}