#if DEBUG
namespace Problems_2099;
#endif

public class Solution
{
    public int[] MaxSubsequence(int[] nums, int k)
    {
        PriorityQueue<int, int> pq = new();
        for (int i = 0; i < nums.Length; i++)
        {
            pq.Enqueue(i, nums[i]);
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
        Array.Sort(ret);
        for (int i = 0; i < k; i++)
        {
            ret[i] = nums[ret[i]];
        }
        return ret;
    }
}