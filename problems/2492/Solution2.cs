public class Solution
{
    public int MinScore(int n, int[][] roads)
    {
        int INF = 1 << 30;
        int[] parent = new int[n + 1];
        int[] score = new int[n + 1];
        for (int i = 0; i < n + 1; i++)
        {
            parent[i] = i;
            score[i] = INF;
        }
        int Find(int x)
        {
            if (parent[x] == x) return x;
            return parent[x] = Find(parent[x]);
        }
        void Union(int x, int y, int w)
        {
            x = Find(x);
            y = Find(y);
            if (x == y)
            {
                score[x] = Math.Min(score[x], w);
                return;
            }
            parent[y] = x;
            score[x] = score[y] = Math.Min(Math.Min(score[y], score[x]), w);
        }
        foreach (int[] r in roads)
        {
            int u = r[0], v = r[1], w = r[2];
            Union(u, v, w);
        }
        return score[Find(1)];
    }
}
