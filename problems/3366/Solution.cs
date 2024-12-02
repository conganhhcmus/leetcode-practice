namespace Problem_3366;
public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        int[] nums = [2, 4, 3];
        int k = 3;
        int op1 = 2;
        int op2 = 1;
        Console.WriteLine(solution.MinArraySum(nums, k, op1, op2));
    }
    public int MinArraySum(int[] nums, int k, int op1, int op2)
    {
        var dp = new int[nums.Length][][];
        for (int i = 0; i < nums.Length; i++)
        {
            dp[i] = new int[op1 + 1][];
            for (int j = 0; j <= op1; j++)
            {
                dp[i][j] = new int[op2 + 1];
            }
        }

        for (int i = 0; i <= op1; i++)
        {
            for (int j = 0; j <= op2; j++)
            {
                dp[0][i][j] = nums[0];
                if (i == 0 && j == 0)
                {
                    continue;
                }

                if (j == 0)
                {
                    dp[0][i][j] = (nums[0] + 1) / 2;
                }
                else if (i == 0)
                {
                    dp[0][i][j] = nums[0] >= k ? nums[0] - k : nums[0];
                }
                else
                {
                    if (nums[0] < k)
                    {
                        dp[0][i][j] = (nums[0] + 1) / 2;
                    }
                    else if (nums[0] < 2 * k - 1)
                    {
                        var tmp = nums[0] - k;
                        dp[0][i][j] = (tmp + 1) / 2;
                    }
                    else
                    {
                        var tmp = (nums[0] + 1) / 2;
                        dp[0][i][j] = tmp - k;
                    }
                }
            }
        }

        for (int i = 1; i < nums.Length; i++)
        {
            for (int j = 0; j <= op1; j++)
            {
                for (int s = 0; s <= op2; s++)
                {
                    dp[i][j][s] = dp[i - 1][j][s] + nums[i];
                    if (j > 0)
                    {
                        var tmp = dp[i - 1][j - 1][s] + (nums[i] + 1) / 2;
                        dp[i][j][s] = Math.Min(dp[i][j][s], tmp);
                    }

                    if (s > 0)
                    {
                        if (nums[i] >= k)
                        {
                            dp[i][j][s] = Math.Min(dp[i][j][s], dp[i - 1][j][s - 1] + nums[i] - k);
                        }
                    }

                    if (j > 0 && s > 0)
                    {
                        if (nums[i] < k)
                        {
                            continue;
                        }

                        if (nums[i] < 2 * k - 1)
                        {
                            var tmp = (nums[i] - k + 1) / 2;
                            dp[i][j][s] = Math.Min(dp[i][j][s], dp[i - 1][j - 1][s - 1] + tmp);
                        }
                        else
                        {
                            var tmp = (nums[i] + 1) / 2 - k;
                            dp[i][j][s] = Math.Min(dp[i][j][s], dp[i - 1][j - 1][s - 1] + tmp);
                        }
                    }
                }
            }
        }

        return dp[nums.Length - 1][op1][op2];
    }
}