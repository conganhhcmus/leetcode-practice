#if DEBUG
namespace Weekly_447_Q3;
#endif

public class Solution
{
    public int[] ConcatenatedDivisibility(int[] nums, int k)
    {
        Array.Sort(nums);
        int n = nums.Length;

        int[] len = new int[n], modNum = new int[n];
        int maxLen = 0;
        for (int i = 0; i < n; i++)
        {
            modNum[i] = nums[i] % k;
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
        var dp = new bool[1 << n, k];
        dp[FULL, 0] = true;

        for (int mask = FULL - 1; mask >= 0; mask--)
        {
            for (int m = 0; m < k; m++)
            {
                for (int i = 0; i < n; i++)
                {
                    int bit = 1 << i;
                    if ((mask & bit) != 0) continue;
                    // If we place nums[i] next, newMod = (m * 10^len[i] + nums[i]) % k
                    int newMod = (m * pow10[len[i]] + modNum[i]) % k;
                    if (dp[mask | bit, newMod])
                    {
                        dp[mask, m] = true;
                        break;
                    }
                }
            }
        }

        if (!dp[0, 0]) return [];

        var result = new List<int>();
        int curMask = 0, curMod = 0;
        while (curMask != FULL)
        {
            for (int i = 0; i < n; i++)
            {
                int bit = 1 << i;
                if ((curMask & bit) != 0) continue;
                int newMod = (curMod * pow10[len[i]] + modNum[i]) % k;
                if (dp[curMask | bit, newMod])
                {
                    result.Add(nums[i]);
                    curMask |= bit;
                    curMod = newMod;
                    break;
                }
            }
        }

        return [.. result];
    }
}