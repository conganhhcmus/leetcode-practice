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
        // [a1, a2, a3, a4, ... an]
        // min operator of [a1, an] is any val between them
        // so same for other elements
        // min operator of [ai,aj] is val between [ai, aj]
        // so we need choose median is best val
        // if n is odd, best val is nums[n/2], but n is even, best val is between nums[n/2] and nums[n/2+1], we also chose nums[n/2]
        int median = nums[nums.Length / 2];
        int ret = 0;
        foreach (int num in nums)
        {
            ret += Math.Abs(num - median);
        }
        return ret;
    }
}