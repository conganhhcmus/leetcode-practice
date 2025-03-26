#if DEBUG
namespace Problems_2033;
#endif

public class Solution
{
    public int MinOperations(int[][] grid, int x)
    {
        int n = grid.Length, m = grid[0].Length;
        int mod = grid[0][0] % x;
        int[] nums = new int[n * m];
        int idx = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (grid[i][j] % x != mod) return -1;
                nums[idx++] = grid[i][j] / x;
            }
        }

        Array.Sort(nums);
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i] - nums[0];
        }

        int ret = sum;
        for (int i = 1; i < nums.Length; i++)
        {
            int diff = nums[i] - nums[i - 1];
            sum -= diff * (nums.Length - 2 * i);
            ret = Math.Min(ret, sum);
        }
        return ret;
    }
}