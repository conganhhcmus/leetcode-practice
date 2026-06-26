public class Solution
{
    public long CountDistinct(long n)
    {
        string str = n.ToString();
        return DP(0, true, true, false, str);
    }
    Dictionary<(int, bool, bool, bool), long> memo = [];

    long DP(int pos, bool t, bool lz, bool z, string str)
    {
        if (pos >= str.Length)
        {
            if (lz == true) return 0L;
            if (z == true) return 0L;
            return 1L;
        }
        var key = (pos, t, lz, z);
        if (memo.TryGetValue(key, out long cached)) return cached;
        long ans = 0L;
        int limit = t ? str[pos] - '0' : 9;
        for (int d = 0; d <= limit; d++)
        {
            bool nT = t && d == limit;
            bool nLz = lz && d == 0;
            bool nZ = z || (nLz == false && d == 0);
            ans += DP(pos + 1, nT, nLz, nZ, str);
        }
        return memo[key] = ans;
    }
}
