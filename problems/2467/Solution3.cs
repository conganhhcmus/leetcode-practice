public class Solution
{
    public int MostProfitablePath(int[][] edges, int bob, int[] amount)
    {
        int n = amount.Length;
        List<int>[] graph = new List<int>[n];
        for (int i = 0; i < n; i++) graph[i] = [];

        foreach (var edge in edges)
        {
            int u = edge[0], v = edge[1];
            graph[u].Add(v);
            graph[v].Add(u);
        }

        int[] bobTime = new int[n];
        Array.Fill(bobTime, -1);
        DFSBob(graph, bob, -1, 0, bobTime);

        return DFSAlice(graph, 0, -1, 0, amount, bobTime);
    }

    private bool DFSBob(List<int>[] graph, int node, int parent, int time, int[] bobTime)
    {
        if (node == 0)
        {
            bobTime[node] = time;
            return true;
        }

        foreach (int neighbor in graph[node])
        {
            if (neighbor == parent) continue;
            if (DFSBob(graph, neighbor, node, time + 1, bobTime))
            {
                bobTime[node] = time;
                return true;
            }
        }
        return false;
    }

    private int DFSAlice(List<int>[] graph, int node, int parent, int time, int[] amount, int[] bobTime)
    {
        int currentProfit = 0;
        if (time < bobTime[node] || bobTime[node] == -1)
        {
            currentProfit = amount[node];
        }
        else if (time == bobTime[node])
        {
            currentProfit = amount[node] / 2;
        }

        int maxChildProfit = int.MinValue;
        foreach (int neighbor in graph[node])
        {
            if (neighbor == parent) continue;
            maxChildProfit = Math.Max(maxChildProfit, DFSAlice(graph, neighbor, node, time + 1, amount, bobTime));
        }

        return currentProfit + (maxChildProfit == int.MinValue ? 0 : maxChildProfit);
    }
}