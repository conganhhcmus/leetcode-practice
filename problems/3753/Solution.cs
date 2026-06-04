public class Solution
{
    public long TotalWaviness(long num1, long num2)
    {
        return Count(num2) - Count(num1 - 1);
    }

    long Count(long num)
    {
        if (num <= 0) return 0L;
        string str = num.ToString();
        long ans = 0L;
        memo.Clear();
        int limit = str[0] - '0';
        for (int d = 0; d <= limit; d++)
        {
            var (sum, _) = DP(1, d != 0, d == limit, 0, d, str);
            ans += sum;
        }
        return ans;
    }

    Dictionary<(int, bool, bool, int, int), (long, long)> memo = [];
    // trend: 0 - equals, 1: greater, -1: less
    (long sum, long count) DP(int pos, bool started, bool tight, int trend, int last, string str)
    {
        int n = str.Length;
        if (pos >= n) return (0, 1);
        var key = (pos, started, tight, trend, last);
        if (memo.TryGetValue(key, out var cached)) return cached;
        long sum = 0L;
        long count = 0L;
        int limit = tight ? (str[pos] - '0') : 9;
        for (int d = 0; d <= limit; d++)
        {
            bool nTight = tight && (d == limit);
            if (!started)
            {
                var (childSum, childCount) = DP(pos + 1, d != 0, nTight, 0, d, str);
                sum += childSum;
                count += childCount;
                continue;
            }
            int nTrend = (d > last) ? 1 : (d < last) ? -1 : 0;
            var (curSum, curCount) = DP(pos + 1, true, nTight, nTrend, d, str);
            if (nTrend * trend < 0)
            {
                sum += curCount;
            }
            sum += curSum;
            count += curCount;
        }

        return memo[key] = (sum, count);
    }
}
