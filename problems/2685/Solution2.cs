public class Solution
{
    public int CountCompleteComponents(int n, int[][] edges)
    {
        List<int>[] graph = new List<int>[n];
        for (int i = 0; i < n; i++) graph[i] = [i];
        foreach (var edge in edges)
        {
            int u = edge[0], v = edge[1];
            graph[u].Add(v);
            graph[v].Add(u);
        }

        Dictionary<string, int> componentFreq = [];
        for (int i = 0; i < n; i++)
        {
            List<int> neighbor = graph[i];
            neighbor.Sort();
            string key = string.Join(",", neighbor);
            componentFreq.TryAdd(key, 0);
            componentFreq[key]++;
        }

        int count = 0;
        foreach (var pair in componentFreq)
        {
            int size = pair.Key.Split(',').Length;
            if (size == pair.Value) count++;
        }
        return count;
    }
}