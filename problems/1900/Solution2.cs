#if DEBUG
namespace Problems_1900_2;
#endif

public class Solution
{
    public int[] EarliestAndLatest(int n, int f, int s)
    {
        if (f > s) (f, s) = (s, f);
        return DP(n, f, s);
    }

    readonly Dictionary<(int, int, int), int[]> memo = [];

    int[] DP(int n, int f, int s)
    {
        var key = (n, f, s);
        if (memo.TryGetValue(key, out int[] cached)) return cached;

        if (f + s == n + 1) return [1, 1];
        if (f + s > n + 1)
        {
            int[] ret = DP(n, n + 1 - s, n + 1 - f);
            return memo[key] = ret;
        }

        int earliest = int.MaxValue, latest = int.MinValue;
        int n_half = (n + 1) / 2;
        if (s <= n_half)
        {
            for (int i = 0; i < f; i++)
            {
                for (int j = 0; j < s - f; j++)
                {
                    int[] ret = DP(n_half, i + 1, i + j + 2);
                    earliest = Math.Min(earliest, ret[0]);
                    latest = Math.Max(latest, ret[1]);
                }
            }
        }
        else
        {
            int s_prime = n + 1 - s;
            int mid = (n - 2 * s_prime + 1) / 2;
            for (int i = 0; i < f; i++)
            {
                for (int j = 0; j < s_prime - f; j++)
                {
                    int[] ret = DP(n_half, i + 1, i + j + mid + 2);
                    earliest = Math.Min(earliest, ret[0]);
                    latest = Math.Max(latest, ret[1]);
                }
            }
        }

        return memo[key] = [earliest + 1, latest + 1];
    }
}