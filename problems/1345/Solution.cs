public class Solution
{
    public int MinJumps(int[] arr)
    {
        int n = arr.Length;
        Dictionary<int, List<int>> map = [];
        for (int i = 0; i < n; i++)
        {
            if (!map.ContainsKey(arr[i])) map[arr[i]] = [];
            map[arr[i]].Add(i);
        }
        int step = 0;
        Queue<int> q = [];
        q.Enqueue(0);
        bool[] vis = new bool[n];
        vis[0] = true;
        while (q.Count > 0)
        {
            int s = q.Count;
            while (s-- > 0)
            {
                int u = q.Dequeue();
                if (u == n - 1) return step;
                if (u - 1 >= 0 && !vis[u - 1])
                {
                    vis[u - 1] = true;
                    q.Enqueue(u - 1);
                }
                if (u + 1 < n && !vis[u + 1])
                {
                    vis[u + 1] = true;
                    q.Enqueue(u + 1);
                }
                if (map.TryGetValue(arr[u], out List<int> list))
                {
                    foreach (int v in list)
                    {
                        if (vis[v]) continue;
                        vis[v] = true;
                        q.Enqueue(v);
                    }
                    map.Remove(arr[u]);
                }
            }

            step++;
        }

        return n;
    }
}
