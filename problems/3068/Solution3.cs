#if DEBUG
namespace Problems_3068_3;
#endif

public class Solution
{
    public long MaximumValueSum(int[] nums, int k, int[][] edges)
    {
        int n = nums.Length;
        memo = new long[n, 2];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                memo[i, j] = -1;
            }
        }
        return DP(0, 1, k, nums);
    }

    long[,] memo;

    long DP(int pos, int isEven, int k, int[] nums)
    {
        if (pos >= nums.Length) return isEven == 1 ? 0 : long.MinValue / 3;
        if (memo[pos, isEven] != -1) return memo[pos, isEven];
        long xor = (nums[pos] ^ k) + DP(pos + 1, isEven ^ 1, k, nums);
        long noXor = nums[pos] + DP(pos + 1, isEven, k, nums);

        return memo[pos, isEven] = Math.Max(xor, noXor);
    }
}