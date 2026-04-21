public class Solution
{
    public int MinimumHammingDistance(int[] source, int[] target, int[][] allowedSwaps)
    {
        int n = source.Length;
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

        Dictionary<int, Dictionary<int, int>> sets = [];
        for (int i = 0; i < n; i++)
        {
            int f = Find(i);
            if (!sets.ContainsKey(f))
            {
                sets[f] = [];
            }
            if (!sets[f].ContainsKey(source[i]))
            {
                sets[f][source[i]] = 0;
            }
            sets[f][source[i]]++;
        }
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            int f = Find(i);
            if (sets[f].ContainsKey(target[i]) && sets[f][target[i]] > 0)
            {
                sets[f][target[i]]--;
            }
            else
            {
                ans++;
            }
        }
        return ans;
    }
}
