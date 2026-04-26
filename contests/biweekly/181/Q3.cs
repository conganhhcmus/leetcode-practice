public class Solution
{
    public int EvenSumSubgraphs(int[] nums, int[][] edges)
    {
        int n = nums.Length;
        int totMask = 1 << n;
        List<int>[] graph = new List<int>[n];
        for (int i = 0; i < n; i++) graph[i] = [];
        foreach (int[] e in edges)
        {
            int u = e[0], v = e[1];
            graph[u].Add(v);
            graph[v].Add(u);
        }

        int ans = 0;

        for (int mask = 1; mask < totMask; mask++)
        {
            int parity = 0;
            int node = -1;
            for (int v = 0; v < n; v++)
            {
                if ((mask & (1 << v)) != 0)
                {
                    parity ^= nums[v];
                    node = v;
                }
            }
            if (parity != 0) continue;
            int visited = 1 << node;
            Queue<int> queue = [];
            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                int u = queue.Dequeue();
                foreach (int v in graph[u])
                {
                    int bit = 1 << v;
                    if (((mask & bit) != 0) && ((visited & bit) == 0))
                    {
                        visited |= bit;
                        queue.Enqueue(v);
                    }
                }
            }
            if (visited == mask) ans++;
        }
        return ans;
    }
}
