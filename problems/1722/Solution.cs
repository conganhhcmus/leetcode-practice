public class Solution
{
    public int MinimumHammingDistance(int[] source, int[] target, int[][] allowedSwaps)
    {
        int n = source.Length;
        int ans = 0;
        bool[] harded = new bool[n];
        Dictionary<int, List<int>> map = [];
        for (int i = 0; i < n; i++)
        {
            if (!map.ContainsKey(source[i]))
            {
                map[source[i]] = [];
            }
            map[source[i]].Add(i);
        }
        int[] parent = new int[n];
        for (int i = 0; i < n; i++)
        {
            parent[i] = i;
        }

        int Find(int x)
        {
            if (parent[x] == x) return x;
            return parent[x] = Find(parent[x]);
        }

        bool Union(int x, int y)
        {
            x = Find(x);
            y = Find(y);
            if (x == y) return false;
            parent[x] = y;
            return true;
        }

        foreach (int[] sw in allowedSwaps)
        {
            Union(sw[0], sw[1]);
        }

        for (int i = 0; i < n; i++)
        {
            if (source[i] == target[i])
            {
                harded[i] = true;
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (source[i] == target[i]) continue;
            List<int> idx = map.GetValueOrDefault(target[i], []);
            int x = Find(i);
            bool ok = false;
            foreach (int id in idx)
            {
                if (harded[id]) continue;
                int y = Find(id);
                if (x == y)
                {
                    ok = true;
                    harded[id] = true;
                    break;
                }
            }
            if (!ok) ans++;
        }

        return ans;
    }
}
