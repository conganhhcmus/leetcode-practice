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

// private class Deque<T>
// {
//     private T[] data;
//     private int head;
//     private int tail;
//     private int size;

//     public Deque(int capacity = 16)
//     {
//         data = new T[capacity];
//         head = 0;
//         tail = 0;
//         size = 0;
//     }

//     public int Count => size;

//     private void Resize()
//     {
//         int newCapacity = data.Length * 2;
//         T[] newData = new T[newCapacity];
//         for (int i = 0; i < size; i++)
//         {
//             newData[i] = data[(head + i) % data.Length];
//         }
//         data = newData;
//         head = 0;
//         tail = size;
//     }

//     public void AddLast(T item)
//     {
//         if (size == data.Length)
//             Resize();
//         data[tail] = item;
//         tail = (tail + 1) % data.Length;
//         size++;
//     }

//     public T RemoveFirst()
//     {
//         if (size == 0)
//             throw new InvalidOperationException("Deque is empty");
//         T item = data[head];
//         head = (head + 1) % data.Length;
//         size--;
//         return item;
//     }

//     public T RemoveLast()
//     {
//         if (size == 0)
//             throw new InvalidOperationException("Deque is empty");
//         tail = (tail - 1 + data.Length) % data.Length;
//         T item = data[tail];
//         size--;
//         return item;
//     }

//     public T First
//     {
//         get
//         {
//             if (size == 0)
//                 throw new InvalidOperationException("Deque is empty");
//             return data[head];
//         }
//     }

//     public T Last
//     {
//         get
//         {
//             if (size == 0)
//                 throw new InvalidOperationException("Deque is empty");
//             return data[(tail - 1 + data.Length) % data.Length];
//         }
//     }
// }