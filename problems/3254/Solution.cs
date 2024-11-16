namespace Problem_3254;

public class Solution
{
    public static void Execute()
    {
        int[] nums = [1, 2, 3, 4, 3, 2, 5];
        int k = 3;
        var solution = new Solution();
        Console.WriteLine($"[{string.Join(",", solution.ResultsArray(nums, k))}]");
    }
    public int[] ResultsArray(int[] nums, int k)
    {
        if (k == 1) return nums;
        int[] dp = new int[nums.Length];
        dp[0] = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] - nums[i - 1] == 1)
            {
                dp[i] = dp[i - 1] + 1;
            }
            else
            {
                dp[i] = 1;
            }
        }

        int[] result = new int[nums.Length - k + 1];

        for (int i = 0; i < result.Length; i++)
        {
            if (dp[i + k - 1] >= k)
            {
                result[i] = nums[i + k - 1];
            }
            else
            {
                result[i] = -1;
            }
        }

        return result;
    }
}