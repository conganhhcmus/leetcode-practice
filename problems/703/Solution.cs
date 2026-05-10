public class KthLargest
{
    PriorityQueue<int, int> pq;
    int n;

    public KthLargest(int k, int[] nums)
    {
        n = k;
        pq = new();
        foreach (int num in nums)
        {
            pq.Enqueue(num, num);
            if (pq.Count > n) pq.Dequeue();
        }
    }

    public int Add(int val)
    {
        pq.Enqueue(val, val);
        if (pq.Count > n) pq.Dequeue();
        return pq.Peek();
    }
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */

#if DEBUG
public class Solution
{
    public List<dynamic> Execute(string[] actions, object[] values)
    {
        List<dynamic> result = [];
        KthLargest kthLargest = null;

        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "KthLargest":
                    object[] data = CastType<object[]>(values[i]);
                    int k = CastType<int>(data[0]);
                    int[] nums = CastType<int[]>(data[1]);
                    kthLargest = new KthLargest(k, nums);
                    result.Add(null);
                    break;
                case "add":
                    int val = CastType<int[]>(values[i])[0];
                    result.Add(kthLargest.Add(val));
                    break;
            }
        }
        return result;
    }

    private static T CastType<T>(object value) => ((JsonElement)value).Deserialize<T>(Program.JsonOptions);
}
#endif
