public class Solution
{
    public int WaysToSplitArray(int[] nums)
    {
        int n = nums.Length;
        long[] prefixSum = new long[n + 1];
        for (int i = 0; i < n; i++) prefixSum[i + 1] = nums[i] + prefixSum[i];
        int ans = 0;
        for (int i = 0; i < n - 1; i++)
        {
            if ((prefixSum[i + 1] << 1) >= prefixSum[n]) ans++;
        }
        return ans;
    }
}