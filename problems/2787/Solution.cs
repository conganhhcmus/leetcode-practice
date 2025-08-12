#if DEBUG
namespace Problems_2787;
#endif

public class Solution
{
    int mod = (int)1e9 + 7;
    public int NumberOfWays(int n, int x)
    {
        HashSet<int> sets = [];
        int cur = 1;
        int index = 1;
        while (cur <= n)
        {
            sets.Add(cur);
            index++;
            cur = FastPow(index, x);
        }

        int m = sets.Count;
        int[] arr = new int[m];
        int idx = 0;
        foreach (int num in sets)
        {
            arr[idx++] = num;
        }

        int[,] memo = new int[m, n + 1];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n + 1; j++)
            {
                memo[i, j] = -1;
            }
        }

        return DP(0, n, arr, memo);
    }

    int DP(int pos, int remain, int[] arr, int[,] memo)
    {
        int n = arr.Length;
        if (remain < 0) return 0;
        if (pos >= n)
        {
            if (remain == 0) return 1;
            return 0;
        }
        if (memo[pos, remain] != -1) return memo[pos, remain];
        int ans = 0;
        ans = (ans + DP(pos + 1, remain, arr, memo)) % mod;
        ans = (ans + DP(pos + 1, remain - arr[pos], arr, memo)) % mod;

        return memo[pos, remain] = ans;
    }

    int FastPow(int a, int b)
    {
        int ans = 1;
        while (b > 0)
        {
            if ((b & 1) != 0) ans *= a;
            a *= a;
            b >>= 1;
        }
        return ans;
    }
}