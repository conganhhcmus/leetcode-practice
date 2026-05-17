public class Solution
{
    public int MaxJumps(int[] arr, int d)
    {
        int n = arr.Length;
        List<int>[] next = new List<int>[n];
        List<int>[] prev = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            next[i] = [];
            prev[i] = [];
        }
        for (int i = 0; i < n; i++)
        {
            // move prev
            for (int j = i - 1; j >= 0; j--)
            {
                if (i - j > d || arr[i] <= arr[j]) break;
                prev[i].Add(j);
            }
            // move next
            for (int j = i + 1; j < n; j++)
            {
                if (j - i > d || arr[i] <= arr[j]) break;
                next[i].Add(j);
            }
        }
        Dictionary<int, int> memo = [];
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            ans = Math.Max(ans, Dp(i));
        }
        return ans;
        int Dp(int u)
        {
            if (memo.TryGetValue(u, out int cache)) return cache;
            int res = 1;
            // move next
            foreach (int v in next[u])
            {
                res = Math.Max(res, 1 + Dp(v));
            }
            // move prev
            foreach (int v in prev[u])
            {
                res = Math.Max(res, 1 + Dp(v));
            }

            return memo[u] = res;
        }
    }
}
