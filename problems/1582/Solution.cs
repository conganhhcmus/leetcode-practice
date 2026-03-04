public class Solution
{
    public int NumSpecial(int[][] mat)
    {
        int m = mat.Length, n = mat[0].Length;
        int[] cols = new int[n];
        int[] rows = new int[m];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (mat[i][j] == 1)
                {
                    rows[i]++;
                    cols[j]++;
                }
            }
        }
        int ans = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (mat[i][j] == 1 && rows[i] == 1 && cols[j] == 1)
                {
                    ans++;
                }
            }
        }

        return ans;
    }
}