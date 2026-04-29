public class Solution
{
    public int[] ShortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges)
    {
        List<int>[] red = new List<int>[n];
        List<int>[] blue = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            red[i] = [];
            blue[i] = [];
        }

        foreach (int[] e in redEdges)
        {
            red[e[0]].Add(e[1]);
        }
        foreach (int[] e in blueEdges)
        {
            blue[e[0]].Add(e[1]);
        }

        int INF = 1 << 30;
        int[,] dist = new int[n, 3];
        // 0: no state, 1: red, 2: blue
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                dist[i, j] = INF;
            }
        }

        Dfs(0, 0, 0);
        int[] ans = new int[n];
        Array.Fill(ans, INF);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                ans[i] = Math.Min(ans[i], dist[i, j]);
            }
            if (ans[i] >= INF) ans[i] = -1;
        }
        return ans;


        void Dfs(int u, int c, int l)
        {
            if (l >= dist[u, c]) return;
            dist[u, c] = l;

            // red
            if (c != 1)
            {
                foreach (int v in red[u])
                {
                    Dfs(v, 1, l + 1);
                }
            }

            // blue
            if (c != 2)
            {
                foreach (int v in blue[u])
                {
                    Dfs(v, 2, l + 1);
                }
            }
        }
    }
}
