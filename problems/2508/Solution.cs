public class Solution
{
    public bool IsPossible(int n, IList<IList<int>> edges)
    {
        int[] degree = new int[n + 1];
        HashSet<int> set = [];
        foreach (var e in edges)
        {
            int u = e[0], v = e[1];
            degree[v]++;
            degree[u]++;
            set.Add(Flatten(u, v));
        }
        List<int> odd = [];
        for (int i = 1; i <= n; i++)
        {
            if (degree[i] % 2 == 1)
            {
                odd.Add(i);
            }
        }
        if (odd.Count == 0) return true;
        if (odd.Count == 2)
        {
            int a = odd[0], b = odd[1];
            if (!set.Contains(Flatten(a, b))) return true;
            for (int i = 1; i <= n; i++)
            {
                if (!set.Contains(Flatten(a, i)) && !set.Contains(Flatten(b, i))) return true;
            }
            return false;
        }

        if (odd.Count == 4)
        {
            int a = odd[0], b = odd[1], c = odd[2], d = odd[3];
            // a - b, c - d
            if (!set.Contains(Flatten(a, b)) && !set.Contains(Flatten(c, d))) return true;
            // a - c, b - d
            if (!set.Contains(Flatten(a, c)) && !set.Contains(Flatten(b, d))) return true;
            // a - d, b - c
            if (!set.Contains(Flatten(a, d)) && !set.Contains(Flatten(b, c))) return true;
            return false;
        }
        return false;
    }

    int Flatten(int a, int b)
    {
        if (a > b) (a, b) = (b, a);
        return a * 100001 + b;
    }
}
