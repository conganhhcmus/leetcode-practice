#if DEBUG
namespace Problems_1411;
#endif

public class Solution
{
    int mod = (int)1e9 + 7;
    public int NumOfWays(int n)
    {
        return (int)DP(0, -1, -1, -1, n);
    }

    Dictionary<(int, int, int, int), long> memo = [];

    long DP(int pos, int c1, int c2, int c3, int n)
    {
        if (pos >= n) return 1;
        var key = (pos, c1, c2, c3);
        if (memo.TryGetValue(key, out long value)) return value;
        long ans = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (i == j || j == k || c1 == i || c2 == j || c3 == k) continue;
                    ans = (ans + DP(pos + 1, i, j, k, n)) % mod;
                }
            }
        }

        return memo[key] = ans;
    }
}