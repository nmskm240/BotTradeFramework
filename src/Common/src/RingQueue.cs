using System.Collections;

namespace BotTrade;

public class RingQueue<T> : IEnumerable<T>
{
    private Queue<T> _queue;

    public int Count => _queue.Count;

    public int Capacity { get; private set; }

    public RingQueue(int capacity)
    {
        Capacity = capacity;
        _queue = new Queue<T>(capacity);
    }

    public void Enqueue(T item)
    {
        _queue.Enqueue(item);

        if (Count > Capacity) Dequeue();
    }

    public T Dequeue() => _queue.Dequeue();

    public T Peek() => _queue.Peek();

    public IEnumerator<T> GetEnumerator() => _queue.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _queue.GetEnumerator();
}
