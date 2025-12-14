#if DEBUG
namespace Problems_2147;
#endif

public class Solution
{
    public int NumberOfWays(string corridor)
    {
        // remove prev and tail 'P'
        corridor = corridor.Trim('P');
        if (corridor.Length < 2) return 0;
        return (int)DP(0, corridor);
    }
    int mod = (int)1e9 + 7;
    Dictionary<int, long> memo = [];

    long DP(int pos, string corridor)
    {
        int n = corridor.Length;
        if (pos >= n) return 1;
        if (memo.TryGetValue(pos, out long value)) return value;
        int i = pos;
        int count = 0;
        while (i < n && count < 2)
        {
            count += corridor[i] == 'S' ? 1 : 0;
            i++;
        }
        if (count < 2) return memo[pos] = 0;
        int can = 1;
        while (i < n && corridor[i] == 'P')
        {
            can++;
            i++;
        }
        return memo[pos] = 1L * can * DP(i, corridor) % mod; ;
    }
}