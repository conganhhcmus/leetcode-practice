public class Solution
{
    public long MaxSum(int[][] grid, int[] limits, int k)
    {
        if (k == 0) return 0;
        List<int> allSelected = [];
        int n = grid.Length, m = grid[0].Length;
        for (int row = 0; row < n; row++)
        {
            Array.Sort(grid[row], (a, b) => b - a);
            for (int s = 0; s < limits[row]; s++)
            {
                allSelected.Add(grid[row][s]);
            }
        }


        allSelected.Sort((a, b) => b - a);
        long ans = 0;
        for (int i = 0; i < k; i++)
        {
            ans += allSelected[i];
        }

        return ans;
    }
}