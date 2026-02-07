public class Solution
{
    public int FindMaxForm(string[] strs, int m, int n)
    {
        int k = strs.Length;
        int[][] count = new int[k][];
        for (int i = 0; i < k; i++)
        {
            count[i] = new int[2];
            foreach (char c in strs[i])
            {
                if (c == '0')
                {
                    count[i][0]++;
                }
                else
                {
                    count[i][1]++;
                }
            }
        }
        return DP(count, 0, m, n);
    }

    Dictionary<(int, int, int), int> memo = [];

    int DP(int[][] count, int pos, int m, int n)
    {
        int k = count.Length;
        if (pos >= k) return 0;
        var key = (pos, m, n);
        if (memo.TryGetValue(key, out int cache)) return cache;
        int ans = 0;
        if (count[pos][0] <= m && count[pos][1] <= n)
        {
            ans = 1 + DP(count, pos + 1, m - count[pos][0], n - count[pos][1]);
        }
        ans = Math.Max(ans, DP(count, pos + 1, m, n));

        return memo[key] = ans;
    }
}