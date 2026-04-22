public class Solution
{
    public int LargestComponentSize(int[] nums)
    {
        int n = nums.Length;
        int[] parent = new int[n];
        int[] size = new int[n];
        for (int i = 0; i < n; i++)
        {
            parent[i] = i;
            size[i] = 1;
        }
        int Find(int x)
        {
            if (parent[x] == x) return x;
            return parent[x] = Find(parent[x]);
        }
        void Union(int x, int y)
        {
            x = Find(x);
            y = Find(y);
            if (x == y) return;
            parent[x] = y;
            size[y] += size[x];
        }

        int MAX = 1000000;
        int[] spf = new int[MAX + 1];

        for (int i = 1; i <= MAX; i++) spf[i] = i;

        for (int i = 2; i * i <= MAX; i++)
        {
            if (spf[i] == i)
            { // i is prime
                for (int j = i * i; j <= MAX; j += i)
                {
                    if (spf[j] == j)
                    {
                        spf[j] = i;
                    }
                }
            }
        }

        int ans = 0;
        Dictionary<int, List<int>> map = [];
        for (int i = 0; i < n; i++)
        {
            int x = nums[i];
            HashSet<int> factors = [];
            while (x != 1)
            {
                factors.Add(spf[x]);
                x /= spf[x];
            }
            foreach (int val in factors)
            {
                if (!map.ContainsKey(val))
                {
                    map[val] = [];
                }
                map[val].Add(i);
            }
        }

        foreach (List<int> idx in map.Values)
        {
            for (int i = 1; i < idx.Count; i++)
            {
                Union(idx[i - 1], idx[i]);
            }
        }

        for (int i = 0; i < n; i++)
        {
            ans = Math.Max(ans, size[Find(i)]);
        }

        return ans;
    }
}
