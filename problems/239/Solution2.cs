public class Solution
{
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        int n = nums.Length;
        LinkedList<int> dq = new();
        for (int i = 0; i < k; i++)
        {
            while (dq.Count > 0 && dq.Last.Value < nums[i])
            {
                dq.RemoveLast();
            }
            dq.AddLast(nums[i]);
        }
        int len = n - k + 1;
        int[] ret = new int[len];
        ret[0] = dq.First.Value;
        int idx = 1;
        for (int i = k; i < n; i++)
        {
            while (dq.Count > 0 && dq.Last.Value < nums[i])
            {
                dq.RemoveLast();
            }
            dq.AddLast(nums[i]);
            if (nums[i - k] == dq.First.Value)
            {
                dq.RemoveFirst();
            }
            ret[idx++] = dq.First.Value;
        }
        return ret;
    }
}