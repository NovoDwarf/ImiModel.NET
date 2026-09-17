using ImiModel.NET.Core.Models.Base;

namespace ImiModel.NET.Core.Models.Abstracts.Commons.Options;

public class StorageOptions : NodeOptions
{
	public int Capacity { get; set; } = -1;

	/// <summary>
	///  Gets the storage queue containing requests currently being processed by the node.
	/// </summary>
	public IStorage<Request> Storage { get; set; } = new LifoStorage<Request>();
}

public class LifoStorage<T> : IStorage<T>
{
    private readonly Stack<T> _items = new();

    public int Count => _items.Count;

    public bool IsEmpty => _items.Count == 0;
    
    public T? Dequeue()
    {
        return _items.Count > 0
            ? _items.Pop()
            : default;
    }

    public void Enqueue(T item)
    {
        _items.Push(item);
    }

    public T? Peek()
    {
        return _items.Count > 0
            ? _items.Peek()
            : default;
    }
}

public interface IStorage<T>
{
	public int Count { get; }
	
	public bool IsEmpty { get; }
	
	public T? Dequeue();
	public void Enqueue(T request);
	public T? Peek();
}