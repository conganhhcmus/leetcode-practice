public class Solution
{
    public long GoodIntegers(long l, long r, int k)
    {
        return Count(r, k) - Count(l - 1, k);
    }

    Dictionary<(int, bool, bool, int, int), long> memo = [];

    long Count(long n, int k)
    {
        string str = n.ToString();
        memo.Clear();
        long ans = 0;
        int max = str[0] - '0';
        for (int d = 0; d <= max; d++)
        {
            bool tight = d == max;
            bool leadingZero = d == 0;
            int cnt = leadingZero ? 0 : 1;
            ans += DP(1, tight, leadingZero, cnt, d, k, str);
        }
        return ans;
    }

    long DP(int pos, bool tight, bool leadingZero, int cnt, int last, int k, string str)
    {
        int n = str.Length;
        if (pos >= n) return cnt < 2 ? 0 : 1;
        var key = (pos, tight, leadingZero, cnt, last);
        if (memo.TryGetValue(key, out long cached)) return cached;
        int max = tight ? (str[pos] - '0') : 9;
        long ans = 0;
        for (int d = 0; d <= max; d++)
        {
            bool nTight = tight && (d == max);
            bool nLeadingZero = leadingZero && (d == 0);
            int nCnt = nLeadingZero ? 0 : cnt + 1;
            if (leadingZero || Math.Abs(last - d) <= k)
            {
                ans += DP(pos + 1, nTight, nLeadingZero, nCnt, d, k, str);
            }
        }
        return memo[key] = ans;
    }
}
