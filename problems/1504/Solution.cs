#if DEBUG
namespace Problems_1504;
#endif

public class Solution
{
    public int NumSubmat(int[][] mat)
    {
        int ans = 0;
        int m = mat.Length, n = mat[0].Length;
        int[][] row = new int[m][];
        for (int i = 0; i < m; i++)
        {
            row[i] = new int[n];
        }
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (j == 0) row[i][j] = mat[i][j];
                else row[i][j] = mat[i][j] == 0 ? 0 : row[i][j - 1] + 1;

                int cur = row[i][j];
                for (int k = i; k >= 0; k--)
                {
                    cur = Math.Min(cur, row[k][j]);
                    if (cur == 0) break;
                    ans += cur;
                }
            }
        }

        return ans;
    }
}