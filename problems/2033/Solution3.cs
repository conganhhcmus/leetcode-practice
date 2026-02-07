public class Solution
{
    public int MinOperations(int[][] grid, int x)
    {
        int n = grid.Length, m = grid[0].Length;
        int mod = grid[0][0] % x;
        int[] nums = new int[n * m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (grid[i][j] % x != mod) return -1;
                nums[i * m + j] = grid[i][j] / x;
            }
        }

        Array.Sort(nums);
        int prefixIdx = 0;
        int suffixIdx = nums.Length - 1;
        int ret = 0;
        while (prefixIdx < suffixIdx)
        {
            if (prefixIdx + suffixIdx < nums.Length - 1)
            {
                int prefixOperations = (prefixIdx + 1) * (nums[prefixIdx + 1] - nums[prefixIdx]);
                ret += prefixOperations;
                prefixIdx++;
            }
            else
            {
                int suffixOperations = (nums.Length - suffixIdx) * (nums[suffixIdx] - nums[suffixIdx - 1]);
                ret += suffixOperations;
                suffixIdx--;
            }
        }
        return ret;
    }
}