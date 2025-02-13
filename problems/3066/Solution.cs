#if DEBUG
namespace Problems_3066;
#endif

public class Solution
{
    public int MinOperations(int[] nums, int k)
    {
        PriorityQueue<int, int> pq = new();
        foreach (int num in nums)
        {
            if (num < k) pq.Enqueue(num, num);
        }
        int ans = 0;
        while (pq.Count > 1)
        {
            int x = pq.Dequeue();
            int y = pq.Dequeue();
            int num = 2 * x + y;
            if (2 * x < k - y) pq.Enqueue(num, num);
            ans++;
        }
        return ans + pq.Count;
    }
}