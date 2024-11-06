using System.Runtime.Intrinsics.Arm;

namespace Problem_3011;

public class Solution
{
    public static void Execute()
    {
        int[] nums = [8, 4, 2, 30, 15];
        var solution = new Solution();
        Console.WriteLine(solution.CanSortArray(nums));
    }
    public bool CanSortArray(int[] nums)
    {
        int CountBitSet(int n)
        {
            int count = 0;
            while (n > 0)
            {
                count += n & 1;
                n >>= 1;
            }
            return count;
        }
        int n = nums.Length;
        int[] dp = new int[n];

        for (int i = 0; i < n; i++)
        {
            dp[i] = CountBitSet(nums[i]);
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - 1; j++)
            {
                if (nums[j] > nums[j + 1])
                {
                    if (dp[j] != dp[j + 1]) return false;
                    (nums[j], nums[j + 1]) = (nums[j + 1], nums[j]);
                }
            }
        }

        return true;
    }
}