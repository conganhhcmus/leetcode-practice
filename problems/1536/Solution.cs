public class Solution
{
    public int MinSwaps(int[][] grid)
    {
        int n = grid.Length;
        int ans = 0;
        int[] zeros = new int[n];
        for (int r = 0; r < n; r++)
        {
            int count = 0;
            for (int c = n - 1; c >= 0; c--)
            {
                if (grid[r][c] == 1) break;
                count++;
            }
            zeros[r] = count;
        }

        for (int r = 0; r < n; r++)
        {
            // need = n - i - 1 tail zeros
            // find the nearest possible position
            int need = n - r - 1;
            int pos = -1;
            for (int i = r; i < n; i++)
            {
                if (zeros[i] >= need)
                {
                    pos = i;
                    break;
                }
            }
            if (pos == -1) return -1;

            // swap
            for (int i = pos; i > r; i--)
            {
                (zeros[i], zeros[i - 1]) = (zeros[i - 1], zeros[i]);
                ans++;
            }
        }

        return ans;
    }
}