namespace Structures;

public class Deque<T>
{
    private readonly LinkedList<T> list = new();

    public void AddFirst(T item) => list.AddFirst(item);
    public void AddLast(T item) => list.AddLast(item);
    public T RemoveFirst()
    {
        var value = list.First.Value;
        list.RemoveFirst();
        return value;
    }
    public int Count => list.Count;
}