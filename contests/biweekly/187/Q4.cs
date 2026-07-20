public class Solution
{
    public int MinCost(string source, string target, IList<IList<string>> rules, int[] costs)
    {
        if (source == target) return 0;
        int n = source.Length;
        // cost[i][j] = min cost from i to j
        // cost[i][j] = cost[i][x] + cost[x][j]
        // ans = cost[0][n-1]
        int INF = 1 << 30;
        int[,] cost = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                cost[i, j] = INF;
            }
        }
        for (int i = 0; i < n; i++)
        {
            if (source[i] == target[i]) cost[i, i] = 0;
        }
        for (int k = 0; k < rules.Count; k++)
        {
            string u = rules[k][0], v = rules[k][1];
            int extra = 0;
            foreach (char c in u)
            {
                if (c == '*') extra++;
            }

            for (int i = 0; i + u.Length <= n; i++)
            {
                int j = i + u.Length;
                if (Ok(i, j, u, v))
                {
                    cost[i, j - 1] = Math.Min(cost[i, j - 1], costs[k] + extra);
                }
            }
        }
        for (int i = 0; i < n; i++)
        {
            if (cost[0, i] >= INF) continue;
            for (int j = i + 1; j < n; j++)
            {
                cost[0, j] = Math.Min(cost[0, j], cost[0, i] + cost[i + 1, j]);
            }
        }
        int ans = cost[0, n - 1];
        return ans >= INF ? -1 : ans;

        bool Ok(int st, int ed, string u, string v)
        {
            for (int i = st, j = 0; i < ed; i++)
            {
                if (target[i] != v[j]) return false;
                j++;
            }

            for (int i = st, j = 0; i < ed; i++)
            {
                if (source[i] != u[j] && u[j] != '*') return false;
                j++;
            }
            return true;
        }
    }
}
