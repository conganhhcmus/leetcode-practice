#if DEBUG
namespace Problems_706;
#endif

public class Node
{
    public int Key;
    public int Val;

    public Node Next;
    public Node(int key, int val)
    {
        Key = key;
        Val = val;
        Next = null;
    }
}

public class MyHashMap
{
    Node[] buckets;
    int maxSize = 1000;
    int Hash(int key)
    {
        return key % maxSize;
    }
    public MyHashMap()
    {
        buckets = new Node[maxSize];
    }

    public void Put(int key, int value)
    {
        int hash = Hash(key);
        Node curr = buckets[hash];
        if (curr == null)
        {
            buckets[hash] = new(key, value);
            return;
        }

        Node prev = null;
        while (curr != null)
        {
            if (curr.Key == key)
            {
                curr.Val = value;
                return;
            }
            prev = curr;
            curr = curr.Next;
        }
        prev.Next = new Node(key, value);
    }

    public int Get(int key)
    {
        int hash = Hash(key);
        Node curr = buckets[hash];
        while (curr != null)
        {
            if (curr.Key == key) return curr.Val;
            curr = curr.Next;
        }
        return -1;
    }

    public void Remove(int key)
    {
        int hash = Hash(key);
        Node curr = buckets[hash];
        Node prev = null;
        while (curr != null)
        {
            if (curr.Key == key)
            {
                if (prev == null)
                {
                    buckets[hash] = curr.Next;
                }
                else
                {
                    // head.Val = -1;
                    prev.Next = curr.Next;
                }
                return;
            }
            prev = curr;
            curr = curr.Next;
        }
    }
}

/**
 * Your MyHashMap object will be instantiated and called as such:
 * MyHashMap obj = new MyHashMap();
 * obj.Put(key,value);
 * int param_2 = obj.Get(key);
 * obj.Remove(key);
 */

public class Solution
{
    public List<dynamic> Execute(string[] actions, int[][] values)
    {
        List<dynamic> result = [];
        MyHashMap myHashMap = null;
        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "MyHashMap":
                    myHashMap = new MyHashMap();
                    result.Add(null);
                    break;
                case "put":
                    myHashMap.Put(values[i][0], values[i][1]);
                    result.Add(null);
                    break;
                case "get":
                    result.Add(myHashMap.Get(values[i][0]));
                    break;
                case "remove":
                    myHashMap.Remove(values[i][0]);
                    result.Add(null);
                    break;
                default:
                    break;
            }
        }
        return result;
    }
}