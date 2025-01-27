namespace Library;

// PriorityQueue implementation for C#
public class PriorityQueue<T> where T : IComparable<T>
{
    private readonly List<T> _heap = [];

    public int Count => _heap.Count;

    public void Enqueue(T item)
    {
        _heap.Add(item);
        int i = _heap.Count - 1;
        while (i > 0)
        {
            int parent = (i - 1) / 2;
            if (_heap[parent].CompareTo(_heap[i]) <= 0) break;

            Swap(parent, i);
            i = parent;
        }
    }

    public T Dequeue()
    {
        int lastIndex = _heap.Count - 1;
        T frontItem = _heap[0];
        _heap[0] = _heap[lastIndex];
        _heap.RemoveAt(lastIndex);

        --lastIndex;
        int parent = 0;
        while (true)
        {
            int leftChild = parent * 2 + 1;
            if (leftChild > lastIndex) break;

            int rightChild = leftChild + 1;
            if (rightChild <= lastIndex && _heap[leftChild].CompareTo(_heap[rightChild]) > 0)
                leftChild = rightChild;

            if (_heap[parent].CompareTo(_heap[leftChild]) <= 0) break;

            Swap(parent, leftChild);
            parent = leftChild;
        }

        return frontItem;
    }

    private void Swap(int i, int j)
    {
        (_heap[j], _heap[i]) = (_heap[i], _heap[j]);
    }
}