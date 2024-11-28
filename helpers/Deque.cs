namespace Helpers.Deque;

public class Deque<T>
{
    private LinkedList<T> list = new LinkedList<T>();

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