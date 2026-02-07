public class Solution
{
    public int ShortestSubarray(int[] nums, int k)
    {
        int n = nums.Length;
        var deque = new LinkedList<(long sum, int index)>();
        deque.AddLast((0, -1));
        int minLen = int.MaxValue;
        long curSum = 0;
        for (int i = 0; i < n; i++)
        {
            curSum += nums[i];
            while (deque.Count > 0 && curSum - deque.First.Value.sum >= k)
            {
                minLen = Math.Min(minLen, i - deque.First.Value.index);
                deque.RemoveFirst();
            }

            while (deque.Count > 0 && curSum < deque.Last.Value.sum)
            {
                deque.RemoveLast();
            }

            deque.AddLast((curSum, i));
        }

        return minLen == n + 1 ? -1 : minLen;
    }
}
