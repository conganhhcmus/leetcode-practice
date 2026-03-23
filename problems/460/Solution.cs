public class LFUCache
{
    class Node
    {
        public int Key;
        public int Val;
        public int Freq;
        public Node Next;
        public Node Prev;
        public Node(int key, int val)
        {
            Key = key;
            Val = val;
            Freq = 1;
            Next = Prev = null;
        }
    }

    class DoubleLinkedList
    {
        public Node Head;
        public Node Tail;
        public int Count;
        public DoubleLinkedList()
        {
            Head = new(0, 0);
            Tail = new(0, 0);
            Head.Next = Tail;
            Tail.Prev = Head;
            Count = 0;
        }

        public void AddFirst(Node node)
        {
            Node first = Head.Next;
            Head.Next = node;
            node.Prev = Head;
            node.Next = first;
            first.Prev = node;
            Count++;
        }

        public void Remove(Node node)
        {
            Node prev = node.Prev;
            Node next = node.Next;
            prev.Next = next;
            next.Prev = prev;
            Count--;
        }

        public Node RemoveLast()
        {
            Node last = Tail.Prev;
            Remove(last);
            return last;
        }
    }

    int capacity;

    Dictionary<int, Node> nodeMap;

    Dictionary<int, DoubleLinkedList> freqMap;

    int minFreq;

    public LFUCache(int capacity)
    {
        this.capacity = capacity;
        minFreq = 1;
        nodeMap = [];
        freqMap = [];
    }

    void IncrementFreq(Node node)
    {
        freqMap[node.Freq].Remove(node);
        if (freqMap[node.Freq].Count == 0)
        {
            freqMap.Remove(node.Freq);
            if (node.Freq == minFreq) minFreq++;
        }
        node.Freq++;
        if (!freqMap.ContainsKey(node.Freq))
        {
            freqMap[node.Freq] = new();
        }
        freqMap[node.Freq].AddFirst(node);
    }

    public int Get(int key)
    {
        if (!nodeMap.ContainsKey(key)) return -1;
        Node node = nodeMap[key];
        IncrementFreq(node);
        return node.Val;
    }

    public void Put(int key, int value)
    {
        if (capacity == 0) return;
        if (nodeMap.ContainsKey(key))
        {
            Node node = nodeMap[key];
            node.Val = value;
            IncrementFreq(node);
            return;
        }

        if (nodeMap.Count >= capacity)
        {
            Node last = freqMap[minFreq].RemoveLast();
            nodeMap.Remove(last.Key);
        }
        Node node = new(key, value);
        if (!freqMap.ContainsKey(node.Freq))
        {
            freqMap[node.Freq] = new();
        }
        freqMap[node.Freq].AddFirst(node);
        nodeMap[node.Key] = node;
        minFreq = 1;
    }
}

/**
 * Your LFUCache object will be instantiated and called as such:
 * LFUCache obj = new LFUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */

public class Solution
{
    public List<int?> Execute(string[] events, int[][] values)
    {
        List<int?> result = [];
        LFUCache lfuCache = null;

        for (int i = 0; i < events.Length; i++)
        {
            switch (events[i])
            {
                case "LFUCache":
                    lfuCache = new LFUCache(values[i][0]);
                    result.Add(null);
                    break;
                case "get":
                    result.Add(lfuCache.Get(values[i][0]));
                    break;
                case "put":
                    lfuCache.Put(values[i][0], values[i][1]);
                    result.Add(null);
                    break;
            }
        }

        return result;
    }
}