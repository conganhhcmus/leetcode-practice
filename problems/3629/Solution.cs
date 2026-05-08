public class Solution
{
    public int MinJumps(int[] nums)
    {
        int n = nums.Length;
        Dictionary<int, List<int>> map = [];
        for (int i = 0; i < n; i++)
        {
            int x = nums[i];
            int d = 2;
            while (d * d <= x)
            {
                if (x % d == 0)
                {
                    if (!map.ContainsKey(d)) map[d] = [];
                    map[d].Add(i);
                    while (x % d == 0) x /= d;
                }
                d++;
            }
            if (x > 1)
            {
                if (!map.ContainsKey(x)) map[x] = [];
                map[x].Add(i);
            }
        }

        Queue<int> q = new();
        bool[] vis = new bool[n];
        q.Enqueue(0);
        vis[0] = true;
        int step = 0;
        while (q.Count > 0)
        {
            int sz = q.Count;
            while (sz-- > 0)
            {
                int i = q.Dequeue();
                if (i == n - 1) return step;
                // jump left
                if (i - 1 >= 0 && !vis[i - 1])
                {
                    vis[i - 1] = true;
                    q.Enqueue(i - 1);
                }
                // jump right
                if (i + 1 < n && !vis[i + 1])
                {
                    vis[i + 1] = true;
                    q.Enqueue(i + 1);
                }
                // jump prime
                int x = nums[i];
                if (x > 1)
                {
                    if (map.TryGetValue(x, out var list))
                    {
                        foreach (int idx in list)
                        {
                            if (!vis[idx])
                            {
                                vis[idx] = true;
                                q.Enqueue(idx);
                            }
                        }

                        map.Remove(x);
                    }
                }
            }

            step++;
        }

        return -1;
    }
}
