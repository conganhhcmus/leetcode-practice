public class Solution
{
    public long CountSubarrays(int[] nums, long k)
    {
        long ans = 0;
        int n = nums.Length;
        LinkedList<int> minQ = new();
        LinkedList<int> maxQ = new();
        for (int l = 0, r = 0; r < n; r++)
        {
            while (minQ.Count > 0 && minQ.Last.Value > nums[r]) minQ.RemoveLast();
            minQ.AddLast(nums[r]);

            while (maxQ.Count > 0 && maxQ.Last.Value < nums[r]) maxQ.RemoveLast();
            maxQ.AddLast(nums[r]);
            while ((long)(r - l + 1) * (maxQ.First.Value - minQ.First.Value) > k)
            {
                if (minQ.First.Value == nums[l]) minQ.RemoveFirst();

                if (maxQ.First.Value == nums[l]) maxQ.RemoveFirst();

                l++;
            }
            ans += (r - l + 1);
        }
        return ans;
    }
}