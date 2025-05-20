#if DEBUG
namespace Problems_3362;
#endif

public class Solution
{
    public int MaxRemoval(int[] nums, int[][] queries)
    {
        int n = nums.Length, m = queries.Length;
        Array.Sort(queries, (a, b) => a[0] - b[0]);
        int[] diff = new int[n + 1];
        PriorityQueue<int, int> pq = new();
        int operations = 0;
        for (int i = 0, j = 0; i < n; i++)
        {
            operations += diff[i];
            while (j < m && queries[j][0] == i)
            {
                pq.Enqueue(queries[j][1], -queries[j][1]);
                j++;
            }
            while (operations < nums[i] && pq.Count > 0 && pq.Peek() >= i)
            {
                operations += 1;
                diff[pq.Dequeue() + 1]--;
            }
            if (operations < nums[i]) return -1;
        }
        return pq.Count;
    }
}