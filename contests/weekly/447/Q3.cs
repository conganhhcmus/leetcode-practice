#if DEBUG
namespace Weekly_447_Q3;
#endif

public class Solution
{
    public int[] ConcatenatedDivisibility(int[] nums, int k)
    {
        Array.Sort(nums);
        int n = nums.Length;

        int[] len = new int[n];
        int maxLen = 0;
        for (int i = 0; i < n; i++)
        {
            len[i] = nums[i].ToString().Length;
            maxLen = Math.Max(maxLen, len[i]);
        }

        int[] pow10 = new int[maxLen + 1];
        pow10[0] = 1 % k;
        for (int i = 1; i <= maxLen; i++)
        {
            pow10[i] = (pow10[i - 1] * 10) % k;
        }

        int FULL = (1 << n) - 1;
        List<int>[,] dp = new List<int>[FULL + 1, k];
        dp[0, 0] = [];

        for (int mask = 0; mask <= FULL; mask++)
        {
            for (int mod = 0; mod < k; mod++)
            {
                if (dp[mask, mod] != null)
                {
                    for (int i = 0; i < n; i++)
                    {
                        int bit = 1 << i;
                        if ((mask & bit) == 0)
                        {
                            int newMod = (mod * pow10[len[i]] + nums[i]) % k;
                            int newMask = mask | bit;
                            List<int> can = [.. dp[mask, mod], nums[i]];
                            if (dp[newMask, newMod] == null || Compare(can, dp[newMask, newMod]) < 0)
                            {
                                dp[newMask, newMod] = can;
                            }
                        }
                    }
                }
            }
        }

        if (dp[FULL, 0] == null) return [];

        return [.. dp[FULL, 0]];
    }

    int Compare(List<int> a, List<int> b)
    {
        int n1 = a.Count, n2 = b.Count;
        int n = Math.Min(n1, n2);
        for (int i = 0; i < n; i++)
        {
            if (a[i] != b[i]) return a[i] - b[i];
        }

        return n1 - n2;
    }
}