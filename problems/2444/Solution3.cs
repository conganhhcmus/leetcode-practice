public class Solution
{
    public long CountSubarrays(int[] nums, int minK, int maxK)
    {
        long ret = 0;
        int n = nums.Length;
        Queue<int> minQ = [];
        Queue<int> maxQ = [];
        int left = 0;
        for (int i = 0; i < n; ++i)
        {
            if (nums[i] < minK || nums[i] > maxK)
            {
                minQ.Clear();
                maxQ.Clear();
                left = i + 1;
                continue;
            }
            while (minQ.Count > 0 && nums[minQ.Peek()] >= nums[i])
            {
                minQ.Dequeue();
            }
            minQ.Enqueue(i);
            while (maxQ.Count > 0 && nums[maxQ.Peek()] <= nums[i])
            {
                maxQ.Dequeue();
            }
            maxQ.Enqueue(i);

            if (nums[minQ.Peek()] == minK && nums[maxQ.Peek()] == maxK)
            {
                int right = Math.Min(minQ.Peek(), maxQ.Peek());
                ret += right - left + 1;
            }
        }
        return ret;
    }
}