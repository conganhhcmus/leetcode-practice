public class Solution
{
    public int MaxProfit(int n, int[] present, int[] future, int[][] hierarchy, int budget)
    {
        List<int>[] graph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = [];
        }
        foreach (int[] e in hierarchy)
        {
            int u = e[0] - 1, v = e[1] - 1;
            graph[u].Add(v);
        }

        return DFS(0, graph, present, future, budget).dp0[budget];
    }

    (int[] dp0, int[] dp1, int size) DFS(int u, List<int>[] graph, int[] present, int[] future, int budget)
    {
        int cost = present[u];
        int dCost = present[u] / 2;
        int[] dp0 = new int[budget + 1];
        int[] dp1 = new int[budget + 1];

        int[] subProfit0 = new int[budget + 1];
        int[] subProfit1 = new int[budget + 1];
        int uSize = cost;

        foreach (int v in graph[u])
        {
            var (childDp0, childDp1, vSize) = DFS(v, graph, present, future, budget);
            uSize += vSize;
            for (int i = budget; i >= 0; i--)
            {
                for (int sub = 0; sub <= Math.Min(vSize, i); sub++)
                {
                    if (i - sub >= 0)
                    {
                        subProfit0[i] = Math.Max(subProfit0[i], subProfit0[i - sub] + childDp0[sub]);
                        subProfit1[i] = Math.Max(subProfit1[i], subProfit1[i - sub] + childDp1[sub]);
                    }
                }
            }
        }

        for (int i = 0; i <= budget; i++)
        {
            dp0[i] = subProfit0[i];
            dp1[i] = subProfit0[i];
            if (i >= dCost)
            {
                dp1[i] = Math.Max(subProfit0[i], subProfit1[i - dCost] + future[u] - dCost);
            }
            if (i >= cost)
            {
                dp0[i] = Math.Max(subProfit0[i], subProfit1[i - cost] + future[u] - cost);
            }
        }
        return (dp0, dp1, uSize);
    }
}