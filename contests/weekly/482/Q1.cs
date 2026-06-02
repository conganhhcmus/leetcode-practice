public class Solution
{
    public long MaximumScore(int[] nums)
    {
        int n = nums.Length;
        long[] pre = new long[n];
        long[] suf = new long[n];
        pre[0] = nums[0];
        for (int i = 1; i < n; i++)
        {
            pre[i] = pre[i - 1] + nums[i];
        }
        suf[n - 1] = nums[n - 1];
        for (int i = n - 2; i >= 0; i--)
        {
            suf[i] = Math.Min(suf[i + 1], nums[i]);
        }
        long ans = long.MinValue;
        for (int i = 0; i < n - 1; i++)
        {
            ans = Math.Max(ans, pre[i] - suf[i + 1]);
        }
        return ans;
    }
}
