public class Solution
{
    const int MAX = 1_000_001;
    const List<int>[] factors = new List<int>[MAX];
    static Solution()
    {
        factors = new List<int>[MAX];
        for (int i = 0; i < MAX; i++) factors[i] = [];
        for (int i = 2; i < MAX; i++)
        {
            if (factors[i].Count == 0)
            {
                // i is prime
                for (int j = i; j < MAX; j += i)
                {
                    factors[j].Add(i);
                }
            }
        }
    }

    public int MinJumps(int[] nums)
    {
        int n = nums.Length;
        Dictionary<int, List<int>> edges = [];
        for (int i = 0; i < n; i++)
        {
            foreach (int p in factors[nums[i]])
            {
                if (!edges.ContainsKey(p)) edges[p] = [];
                edges[p].Add(i);
            }
        }
        List<int> q = [0];
        bool[] vis = new bool[n];
        vis[0] = true;
        int step = 0;
        while (q.Count > 0)
        {
            List<int> q2 = [];
            foreach (int i in q)
            {
                if (i == n - 1) return step;
                // jump left
                if (i - 1 >= 0 && !vis[i - 1])
                {
                    vis[i - 1] = true;
                    q2.Add(i - 1);
                }
                // jump right
                if (i + 1 < n && !vis[i + 1])
                {
                    vis[i + 1] = true;
                    q2.Add(i + 1);
                }
                // jump prime
                int x = nums[i];
                if (factors[x].Count == 1)
                {
                    if (edges.TryGetValue(x, out List<int> indexs))
                    {
                        foreach (int idx in indexs)
                        {
                            if (!vis[idx])
                            {
                                vis[idx] = true;
                                q2.Add(idx);
                            }
                        }
                        edges.Remove(x);
                    }
                }
            }
            q = q2;
            step++;
        }
        return -1;
    }
}
