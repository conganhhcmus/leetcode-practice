public class Solution
{
    public int[] MinEdgeReversals(int n, int[][] edges)
    {
        List<int[]>[] graph = new List<int[]>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = [];
        }
        foreach (int[] e in edges)
        {
            int u = e[0], v = e[1];
            graph[u].Add([v, 0]);
            graph[v].Add([u, 1]);
        }
        int[] ans = new int[n];
        Array.Fill(ans, -1);
        ans[0] = Sum(0, -1, graph);
        Queue<int> queue = [];
        queue.Enqueue(0);
        while (queue.Count > 0)
        {
            int curr = queue.Dequeue();
            foreach (int[] e in graph[curr])
            {
                int next = e[0], cost = e[1];
                if (ans[next] != -1) continue;
                if (cost == 0) ans[next] = ans[curr] + 1;
                else ans[next] = ans[curr] - 1;
                queue.Enqueue(next);
            }
        }
        return ans;
    }

    int Sum(int curr, int prev, List<int[]>[] graph)
    {
        int sum = 0;
        foreach (int[] e in graph[curr])
        {
            int next = e[0], cost = e[1];
            if (next == prev) continue;
            sum += cost + Sum(next, curr, graph);
        }
        return sum;
    }
}