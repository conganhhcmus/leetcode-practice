#if DEBUG
namespace Problems_1947_3;
#endif

public class Solution
{
    public int MaxCompatibilitySum(int[][] students, int[][] mentors)
    {
        int n = students[0].Length;
        int m = students.Length;

        int[][] scores = new int[m][];
        // O(m*m*n)
        for (int i = 0; i < m; i++) scores[i] = new int[m];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < m; j++)
            {
                int count = 0;
                for (int k = 0; k < n; k++)
                {
                    if (students[i][k] == mentors[j][k]) count++;
                }
                scores[i][j] = count;
            }
        }

        int maxB = 1 << m;
        int[][] dp = new int[m][];
        for (int i = 0; i < m; i++) dp[i] = new int[maxB];
        for (int i = 0; i < m; i++)
        {
            dp[0][1 << i] = scores[0][i];
        }
        for (int i = 1; i < m; i++)
        {
            for (int bit = 0; bit < maxB; bit++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((bit & (1 << j)) != 0) continue;
                    int newBit = bit | (1 << j);
                    dp[i][newBit] = Math.Max(dp[i][newBit], scores[i][j] + dp[i - 1][bit]);
                }
            }
        }

        return dp[m - 1][maxB - 1];
    }
}