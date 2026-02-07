public class DoubleLinkedList
{
    public int Key;
    public int Value;
    public DoubleLinkedList Next;
    public DoubleLinkedList Prev;
    public DoubleLinkedList(int key, int value, DoubleLinkedList next = null, DoubleLinkedList prev = null)
    {
        Key = key;
        Value = value;
        Next = next;
        Prev = prev;
    }
}

public class LRUCache
{
    private readonly int _capacity;
    private readonly Dictionary<int, DoubleLinkedList> _cache;

    private readonly DoubleLinkedList _lru;

    private readonly DoubleLinkedList _mostRecent;

    public LRUCache(int capacity)
    {
        _capacity = capacity;
        _cache = [];
        _lru = new DoubleLinkedList(0, 0);
        _mostRecent = new DoubleLinkedList(0, 0);
        _lru.Next = _mostRecent;
        _mostRecent.Prev = _lru;
    }

    private void Delete(DoubleLinkedList node)
    {
        DoubleLinkedList next = node.Next;
        DoubleLinkedList prev = node.Prev;
        prev.Next = next;
        next.Prev = prev;
    }

    private void Add(DoubleLinkedList node)
    {
        DoubleLinkedList prev = _mostRecent.Prev;
        prev.Next = node;
        node.Prev = prev;
        node.Next = _mostRecent;
        _mostRecent.Prev = node;
    }

    public int Get(int key)
    {
        if (!_cache.ContainsKey(key)) return -1;

        DoubleLinkedList node = _cache[key];
        Delete(node);
        Add(node);
        return node.Value;
    }

    public void Put(int key, int value)
    {
        if (_cache.ContainsKey(key))
        {
            DoubleLinkedList node = _cache[key];
            node.Value = value;
            Delete(node);
            Add(node);
        }
        else
        {
            if (_cache.Count == _capacity)
            {
                DoubleLinkedList temp = _lru.Next;
                Delete(temp);
                _cache.Remove(temp.Key);
            }

            DoubleLinkedList node = new(key, value);
            Add(node);
            _cache[key] = node;
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */

public class Solution
{
    public List<int?> Execute(string[] events, int[][] values)
    {
        List<int?> result = [];
        LRUCache lruCache = null;

        for (int i = 0; i < events.Length; i++)
        {
            switch (events[i])
            {
                case "LRUCache":
                    lruCache = new LRUCache(values[i][0]);
                    result.Add(null);
                    break;
                case "get":
                    result.Add(lruCache.Get(values[i][0]));
                    break;
                case "put":
                    lruCache.Put(values[i][0], values[i][1]);
                    result.Add(null);
                    break;
            }
        }

        return result;
    }
}