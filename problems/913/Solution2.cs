public class Solution
{
    public int CatMouseGame(int[][] graph)
    {
        int n = graph.Length;
        int[,,] a = new int[n, n, 2];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
            {
                a[i, j, 0] = -graph[i].Length;
                a[i, j, 1] = -graph[j].Length;
            }
        for (int i = 0; i < n; i++)
            for (int j = 0; j < graph[0].Length; j++)
                a[i, graph[0][j], 1]++;
        Queue<(int, int, int)> q = new();
        for (int i = 1; i < n; i++)
        {
            q.Enqueue((i, i, 0)); a[i, i, 0] = 2000;
            q.Enqueue((i, i, 1)); a[i, i, 1] = 1000;
            q.Enqueue((0, i, 1)); a[0, i, 1] = 2000;
        }
        while (q.Count > 0)
        {
            int[] b = [0, 0];
            (b[0], b[1], int h) = q.Dequeue();
            if (b[0] == 1 && b[1] == 2 && h == 0)
                return a[b[0], b[1], h] / 1000;
            if (a[b[0], b[1], h] == 2000)
            {
                h = 1 - h;
                int t = b[h];
                for (int i = 0; i < graph[t].Length; i++)
                {
                    b[h] = graph[t][i];
                    if (h == 1 && b[h] == 0) continue;
                    if (a[b[0], b[1], h] <= 0)
                    {
                        q.Enqueue((b[0], b[1], h));
                        a[b[0], b[1], h] = 1000;
                    }
                }
            }
            else
            {
                h = 1 - h;
                int t = b[h];
                for (int i = 0; i < graph[t].Length; i++)
                {
                    b[h] = graph[t][i];
                    if (h == 1 && b[h] == 0) continue;
                    if (++a[b[0], b[1], h] == 0)
                    {
                        q.Enqueue((b[0], b[1], h));
                        a[b[0], b[1], h] = 2000;
                    }
                }
            }
        }
        return 0;
    }
}
