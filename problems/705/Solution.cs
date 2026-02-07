#if DEBUG
using System.Collections;

#endif

public class MyHashSet
{
    BitArray buckets;
    int maxKey = (int)1e6 + 1;
    public MyHashSet()
    {
        buckets = new BitArray(maxKey);
    }

    public void Add(int key)
    {
        buckets[key] = true;
    }

    public void Remove(int key)
    {
        buckets[key] = false;
    }

    public bool Contains(int key)
    {
        return buckets[key];
    }
}

/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 */


public class Solution
{
    public List<dynamic> Execute(string[] actions, int[][] values)
    {
        List<dynamic> result = [];
        MyHashSet myHashSet = null;
        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "MyHashSet":
                    myHashSet = new MyHashSet();
                    result.Add(null);
                    break;
                case "add":
                    myHashSet.Add(values[i][0]);
                    result.Add(null);
                    break;
                case "remove":
                    myHashSet.Remove(values[i][0]);
                    result.Add(null);
                    break;
                case "contains":
                    result.Add(myHashSet.Contains(values[i][0]));
                    break;
                default:
                    break;
            }
        }
        return result;
    }
}