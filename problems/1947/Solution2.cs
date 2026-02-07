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

        int[][] memo = new int[m][];
        int maxB = 1 << 8;
        for (int i = 0; i < m; i++)
        {
            memo[i] = new int[maxB];
            Array.Fill(memo[i], -1);
        }
        return DP(scores, 0, 0, m, memo);
    }

    int DP(int[][] score, int x, int bit, int m, int[][] memo)
    {
        if (x >= m) return 0;
        if (memo[x][bit] != -1) return memo[x][bit];
        int ans = 0;
        for (int i = 0; i < m; i++)
        {
            if ((bit & (1 << i)) != 0) continue;
            ans = Math.Max(ans, score[x][i] + DP(score, x + 1, bit | (1 << i), m, memo));
        }
        memo[x][bit] = ans;
        return ans;
    }
}