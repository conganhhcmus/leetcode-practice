public class Solution
{
    public int NumWays(int steps, int arrLen)
    {
        return (int)DP(0, steps, arrLen);
    }
    Dictionary<(int, int), long> memo = [];
    int mod = (int)1e9 + 7;
    long DP(int pos, int remain, int arrLen)
    {
        if (pos > remain) return 0;
        if (remain == 0) return (pos == 0) ? 1 : 0;
        var key = (pos, remain);
        if (memo.TryGetValue(key, out long cache)) return cache;
        long ans = 0;
        // move right
        if (pos + 1 < arrLen) ans = (ans + DP(pos + 1, remain - 1, arrLen)) % mod;
        if (pos - 1 >= 0) ans = (ans + DP(pos - 1, remain - 1, arrLen)) % mod;
        ans = (ans + DP(pos, remain - 1, arrLen)) % mod;
        return memo[key] = ans;
    }
}