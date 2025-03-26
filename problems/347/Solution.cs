#if DEBUG
namespace Problems_347;
#endif

public class Solution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        PriorityQueue<int, int> pq = new(k);
        Dictionary<int, int> freq = [];
        foreach (int num in nums)
        {
            freq[num] = freq.GetValueOrDefault(num, 0) + 1;
        }

        foreach (var pair in freq)
        {
            pq.Enqueue(pair.Key, pair.Value);
            if (pq.Count > k)
            {
                pq.Dequeue();
            }
        }
        int[] ret = new int[k];
        for (int i = 0; i < k; i++)
        {
            ret[i] = pq.Dequeue();
        }
        return ret;
    }
}