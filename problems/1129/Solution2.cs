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
        Queue<(int u, int c)> queue = [];
        queue.Enqueue((0, 0));
        int[] ans = new int[n];
        Array.Fill(ans, -1);
        int dist = 0;
        bool[,] visited = new bool[n, 3];
        visited[0, 0] = true;
        while (queue.Count > 0)
        {
            int s = queue.Count;
            for (int i = 0; i < s; i++)
            {
                var (u, c) = queue.Dequeue();
                if (ans[u] == -1) ans[u] = dist;
                // red
                if (c != 1)
                {
                    foreach (int v in red[u])
                    {
                        if (visited[v, 1]) continue;
                        visited[v, 1] = true;
                        queue.Enqueue((v, 1));
                    }
                }
                // blue
                if (c != 2)
                {
                    foreach (int v in blue[u])
                    {
                        if (visited[v, 2]) continue;
                        visited[v, 2] = true;
                        queue.Enqueue((v, 2));
                    }
                }
            }
            dist++;
        }
        return ans;
    }
}
