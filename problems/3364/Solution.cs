public class Solution
{
    public int MinimumSumSubarray(IList<int> nums, int l, int r)
    {
        int n = nums.Count;
        int[] prefixSum = new int[nums.Count + 1];
        for (int i = 0; i < n; i++)
        {
            prefixSum[i + 1] = prefixSum[i] + nums[i];
        }
        int ans = int.MaxValue;
        for (int i = l; i <= n; i++)
        {
            for (int j = l; j <= r && i - j >= 0; j++)
            {
                int c = prefixSum[i] - prefixSum[i - j];
                if (c > 0)
                {
                    if (ans > c)
                    {
                        ans = c;
                    }
                }
            }
        }

        return ans == int.MaxValue ? -1 : ans;
    }
}