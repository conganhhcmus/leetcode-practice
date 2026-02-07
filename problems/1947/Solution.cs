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

        int ans = 0;
        bool[] picked = new bool[m];
        BackTracking(scores, 0, m, 0, picked, ref ans);
        return ans;
    }

    void BackTracking(int[][] scores, int cur, int m, int val, bool[] picked, ref int ans)
    {
        if (cur == m)
        {
            ans = Math.Max(ans, val);
            return;
        }
        for (int i = 0; i < m; i++)
        {
            if (picked[i]) continue;
            picked[i] = true;
            BackTracking(scores, cur + 1, m, val + scores[cur][i], picked, ref ans);
            picked[i] = false;
        }
    }
}