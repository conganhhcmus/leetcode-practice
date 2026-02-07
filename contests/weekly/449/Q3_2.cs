public class Solution
{
    public long MaxScore(int n, int[][] edges)
    {
        List<int>[] graph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = [];
        }
        foreach (int[] edge in edges)
        {
            int u = edge[0], v = edge[1];
            graph[u].Add(v);
            graph[v].Add(u);
        }
        List<int> cycle = [];
        List<int> line = [];
        bool[] visited = new bool[n];
        for (int i = 0; i < n; i++)
        {
            if (visited[i]) continue;
            List<int> nodes = [];
            Queue<int> queue = [];
            queue.Enqueue(i);
            visited[i] = true;
            while (queue.Count > 0)
            {
                int curr = queue.Dequeue();
                nodes.Add(curr);
                foreach (int next in graph[curr])
                {
                    if (visited[next]) continue;
                    visited[next] = true;
                    queue.Enqueue(next);
                }
            }

            bool isCycle = true;
            foreach (int node in nodes)
            {
                if (graph[node].Count == 1)
                {
                    isCycle = false;
                    break;
                }
            }
            if (isCycle)
            {
                cycle.Add(nodes.Count);
            }
            else
            {
                line.Add(nodes.Count);
            }
        }

        cycle.Sort((a, b) => b - a);
        line.Sort((a, b) => b - a);
        long ret = 0;
        foreach (int k in cycle)
        {
            ret += Compute(n - k + 1, n, true);
            n -= k;
        }
        foreach (int k in line)
        {
            ret += Compute(n - k + 1, n, false);
            n -= k;
        }

        return ret;
    }

    long Compute(int l, int r, bool isCycle)
    {
        LinkedList<long> dequeue = new();
        dequeue.AddLast(r);
        dequeue.AddLast(r);
        long ret = 0;
        for (int i = r - 1; i >= l; i--)
        {
            ret += dequeue.First.Value * i;
            dequeue.RemoveFirst();
            dequeue.AddLast(i);
        }
        if (isCycle) ret += dequeue.First.Value * dequeue.Last.Value;
        return ret;
    }
}