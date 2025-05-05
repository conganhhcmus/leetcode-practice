#if DEBUG
namespace Problems_790_2;
#endif

public class Solution
{
    int mod = (int)1e9 + 7;
    public int NumTilings(int n)
    {
        int[][] memo = new int[n + 1][];
        for (int i = 0; i <= n; i++)
        {
            memo[i] = [-1, -1];
        }
        return DP(0, n, false, memo);
    }

    int DP(int pos, int n, bool halfFill, int[][] memo)
    {
        // halfFill = false when both cell at pos column are empty, otherwise halfFill = true
        if (pos == n) return halfFill ? 0 : 1;
        if (pos > n) return 0;
        int halfFillVal = Convert.ToInt32(halfFill);
        if (memo[pos][halfFillVal] != -1) return memo[pos][halfFillVal];
        int ret = 0;
        if (halfFill)
        {
            // fill L , next = pos+1, halfFill = false (1 way)
            // fill -- , next = pos+1, halfFill = true (1 way)
            ret = (DP(pos + 1, n, false, memo) + DP(pos + 1, n, true, memo)) % mod;
        }
        else
        {
            // fill | , next = pos+1, halfFill = false (1 way)
            // fill == , next = pos+2, halfFill = false (1 way)
            // fill L , next = pos+2, need fill = true (2 ways)
            ret = ((DP(pos + 1, n, false, memo) + DP(pos + 2, n, false, memo)) % mod + 2 * DP(pos + 2, n, true, memo) % mod) % mod;
        }

        memo[pos][halfFillVal] = ret;
        return ret;
    }
}