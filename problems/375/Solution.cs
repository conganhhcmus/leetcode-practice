#if DEBUG
namespace Problems_375;
#endif

public class Solution
{
    public int GetMoneyAmount(int n)
    {
        int[][] memo = new int[n + 1][];
        for (int i = 0; i <= n; i++)
        {
            memo[i] = new int[n + 1];
            Array.Fill(memo[i], -1);
        }
        return DP(1, n, memo);
    }

    int DP(int st, int ed, int[][] memo)
    {
        if (st >= ed) return 0;
        if (memo[st][ed] != -1) return memo[st][ed];
        int ret = int.MaxValue;
        for (int i = st; i <= ed; i++)
        {
            ret = Math.Min(ret, i + Math.Max(DP(st, i - 1, memo), DP(i + 1, ed, memo)));
        }
        memo[st][ed] = ret;
        return ret;
    }
}