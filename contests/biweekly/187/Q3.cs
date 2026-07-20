public class Solution
{
    public int MinAdjacentSwaps(int[] nums, int a, int b)
    {
        int n = nums.Length;
        int MOD = 1_000_000_007;
        long ans = 0;
        int st = 0;
        long sum = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] < a)
            {
                sum = (sum + i - st) % MOD;
                ans = (ans + sum) % MOD;
                st = i + 1;
            }
        }
        sum = 0;
        int ed = n - 1;
        int skip = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            if (nums[i] > b)
            {
                sum = (sum + ed - i - skip) % MOD;
                ans = (ans + sum) % MOD;
                ed = i - 1;
                skip = 0;
            }
            if (nums[i] < a) skip++;
        }
        return (int)ans;
    }
}
