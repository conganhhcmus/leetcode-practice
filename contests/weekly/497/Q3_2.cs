public class Solution
{
    public int LongestBalanced(string s)
    {
        int n = s.Length;
        int ones = 0;
        for (int i = 0; i < n; i++)
        {
            if (s[i] == '1')
                ones++;
        }
        int zeros = n - ones;
        int max = 2 * Math.Min(zeros, ones);
        if (max == 0)
            return 0;
        int ans = 0;
        int bal = 0;
        Dictionary<int, List<int>> map = [];
        map[0] = [-1];
        for (int r = 0; r < n; r++)
        {
            if (s[r] == '1')
                bal++;
            else
                bal--;
            int l = r - max;

            ans = Math.Max(ans, Solve(map, bal, l, r));
            ans = Math.Max(ans, Solve(map, bal - 2, l, r));
            ans = Math.Max(ans, Solve(map, bal + 2, l, r));

            if (!map.ContainsKey(bal))
            {
                map[bal] = [];
            }
            map[bal].Add(r);
        }

        return ans;
    }

    int INF = int.MaxValue / 2;

    int Solve(Dictionary<int, List<int>> map, int bal, int t, int r)
    {
        if (!map.ContainsKey(bal))
            return 0;
        int l = BinarySearch(map[bal], t);
        if (l == INF)
            return 0;
        return r - l;
    }

    int BinarySearch(List<int> idx, int target)
    {
        int l = 0,
            r = idx.Count - 1,
            ans = INF;
        while (l <= r)
        {
            int m = l + (r - l) / 2;
            if (idx[m] >= target)
            {
                ans = idx[m];
                r = m - 1;
            }
            else
            {
                l = m + 1;
            }
        }
        return ans;
    }
}
