public class Solution
{
    public int NumberOfComponents(int[][] properties, int k)
    {
        int n = properties.Length, m = properties[0].Length;
        List<int>[] graph = new List<int>[n];
        for (int i = 0; i < n; i++) graph[i] = [];
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (Intersect(properties[i], properties[j]) >= k)
                {
                    graph[i].Add(j);
                    graph[j].Add(i);
                }
            }
        }

        int ans = 0;
        bool[] visited = new bool[n];
        for (int i = 0; i < n; i++)
        {
            if (visited[i]) continue;
            ans++;
            Queue<int> queue = [];
            queue.Enqueue(i);
            visited[i] = true;
            while (queue.Count > 0)
            {
                int curr = queue.Dequeue();
                foreach (var neighbor in graph[curr])
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }

        return ans;
    }

    int Intersect(int[] a, int[] b)
    {
        HashSet<int> set = [.. a];
        HashSet<int> set2 = [];
        int count = 0;
        for (int i = 0; i < b.Length; i++)
        {
            if (set2.Add(b[i]))
            {
                if (set.Contains(b[i])) count++;
            }
        }
        return count;
    }
}