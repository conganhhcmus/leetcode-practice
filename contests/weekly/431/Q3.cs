#if DEBUG
namespace Contests_431_Q3;
#endif

public class Solution
{
    public long MaximumCoins(int[][] coins, int k)
    {
        int n = coins.Length;
        Array.Sort(coins, (a, b) => a[0] - b[0]);
        long[] dp = new long[n + 1];
        long ans = 0;

        for (int i = 0; i < n; i++)
        {
            dp[i + 1] = dp[i] + (coins[i][1] - coins[i][0] + 1L) * coins[i][2];
        }

        for (int i = 0; i < n; i++)
        {
            // binary search minimal j with j - i >= k
            int st = i, ed = n - 1, idx = 0;

            while (st <= ed)
            {
                int mid = st + (ed - st) / 2;
                if (coins[mid][1] - coins[i][0] + 1 < k)
                {
                    st = mid + 1;
                }
                else
                {
                    idx = mid;
                    ed = mid - 1;
                }
            }
            long diff = Math.Max(0L, Math.Min(coins[idx][1] - coins[i][0] + 1 - k, coins[idx][1] - coins[idx][0] + 1)) * coins[idx][2];
            ans = Math.Max(ans, dp[idx + 1] - dp[i] - diff);

            // binary search j with i - j >= k
            st = 0;
            ed = i;
            idx = 0;
            while (st <= ed)
            {
                int mid = st + (ed - st) / 2;
                if (coins[i][1] - coins[mid][0] + 1 < k)
                {
                    ed = mid - 1;
                }
                else
                {
                    idx = mid;
                    st = mid + 1;
                }
            }
            diff = Math.Max(0L, Math.Min(coins[i][1] - coins[idx][0] + 1 - k, coins[idx][1] - coins[idx][0] + 1)) * coins[idx][2];
            ans = Math.Max(ans, dp[i + 1] - dp[idx] - diff);
        }

        return ans;
    }
}