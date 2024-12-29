using System.Collections;

namespace BotTrade;

public struct RingQueue<T> : IEnumerable<T>
{
    private Queue<T> _queue;

    public readonly int Count => _queue.Count;
    public readonly bool IsMax => Count >= Capacity;
    public int Capacity { get; init; }

    public RingQueue(int capacity)
    {
        Capacity = capacity;
        _queue = new Queue<T>(capacity);
    }

    public readonly void Enqueue(T item)
    {
        if (IsMax)
            Dequeue();
        _queue.Enqueue(item);
    }

    public readonly T Dequeue() => _queue.Dequeue();

    public readonly T Peek() => _queue.Peek();

    public readonly IEnumerator<T> GetEnumerator() => _queue.GetEnumerator();

    readonly IEnumerator IEnumerable.GetEnumerator() => _queue.GetEnumerator();
}
