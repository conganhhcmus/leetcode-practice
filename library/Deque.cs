namespace Library;

public class Deque<T>
{
    private readonly LinkedList<T> dq;

    public Deque()
    {
        dq = [];
    }

    public void AddFirst(T item) => dq.AddFirst(item);

    public void AddLast(T item) => dq.AddLast(item);

    public T RemoveFirst()
    {
        if (dq.Count == 0) return default;
        T item = dq.First.Value;
        dq.RemoveFirst();
        return item;
    }

    public T RemoveLast()
    {
        if (dq.Count == 0) return default;
        T item = dq.Last.Value;
        dq.RemoveLast();
        return item;
    }

    public T First => dq.First.Value;

    public T Last => dq.Last.Value;

    public int Count => dq.Count;
}