public class Solution
{
    public long CountBalanced(long low, long high)
    {
        return Count(high) - Count(low - 1);
    }

    Dictionary<(int, bool, int), long> memo = [];

    long Count(long n)
    {
        string str = n.ToString();
        memo.Clear();
        return DP(0, true, 0, str);
    }

    long DP(int p, bool tight, int diff, string str)
    {
        int n = str.Length;
        if (p >= n) return diff == 0 ? 1 : 0;
        var key = (p, tight, diff);
        if (memo.TryGetValue(key, out long cache)) return cache;
        long ans = 0;
        int max = tight ? (str[p] - '0') : 9;
        for (int d = 0; d <= max; d++)
        {
            bool nTight = tight && d == max;
            // 1-indexed
            int nDiff = (p % 2 == 0) ? diff + d : diff - d;
            ans += DP(p + 1, nTight, nDiff, str);
        }

        return memo[key] = ans;
    }

}
