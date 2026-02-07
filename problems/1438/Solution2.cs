public class Solution
{
    public int LongestSubarray(int[] nums, int limit)
    {
        int n = nums.Length;
        int ret = 1;
        LinkedList<int> minDequeue = new();
        LinkedList<int> maxDequeue = new();
        int l = 0;
        for (int r = 0; r < n; r++)
        {
            while (maxDequeue.Count > 0 && maxDequeue.Last.Value < nums[r])
            {
                maxDequeue.RemoveLast();
            }
            maxDequeue.AddLast(nums[r]);
            while (minDequeue.Count > 0 && minDequeue.Last.Value > nums[r])
            {
                minDequeue.RemoveLast();
            }
            minDequeue.AddLast(nums[r]);
            // max = maxDequeue.First.Value
            // min = minDequeue.First.Value
            while (l <= r && Math.Abs(maxDequeue.First.Value - minDequeue.First.Value) > limit)
            {
                if (nums[l] == maxDequeue.First.Value)
                {
                    maxDequeue.RemoveFirst();
                }
                if (nums[l] == minDequeue.First.Value)
                {
                    minDequeue.RemoveFirst();
                }
                l++;
            }

            ret = Math.Max(ret, r - l + 1);
        }
        return ret;
    }
}