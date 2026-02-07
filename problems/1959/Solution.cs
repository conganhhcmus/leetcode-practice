public class Solution
{
    public int MinSpaceWastedKResizing(int[] nums, int k)
    {
        int n = nums.Length;
        int[][] memo = new int[n][];
        for (int i = 0; i < n; i++)
        {
            memo[i] = new int[k + 1];
            Array.Fill(memo[i], -1);
        }
        return DP(nums, memo, 0, k);
    }

    int DP(int[] nums, int[][] memo, int i, int k)
    {
        int n = nums.Length;
        if (i == n) return 0;
        if (k == -1) return int.MaxValue / 3;
        if (memo[i][k] != -1) return memo[i][k];
        int ans = int.MaxValue / 3;
        int max = nums[i];
        int sum = 0;
        for (int j = i; j < n; j++)
        {
            max = Math.Max(max, nums[j]);
            sum += nums[j];
            int wasted = max * (j - i + 1) - sum;
            ans = Math.Min(ans, DP(nums, memo, j + 1, k - 1) + wasted);
        }
        return memo[i][k] = ans;
    }
}