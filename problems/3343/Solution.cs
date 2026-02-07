public class Solution
{
    int mod = (int)1e9 + 7;
    long[,] comb;

    int target;

    int[] pSum;

    int[] count;

    long[,,] memo;

    public int CountBalancedPermutations(string num)
    {
        int n = num.Length;
        count = new int[10];
        int tot = 0;
        foreach (char d in num)
        {
            count[d - '0']++;
            tot += d - '0';
        }
        if ((tot & 1) != 0) return 0;
        target = tot / 2;
        int maxOdd = (n + 1) / 2;
        comb = new long[maxOdd + 1, maxOdd + 1];
        for (int i = 0; i <= maxOdd; i++)
        {
            comb[i, i] = comb[i, 0] = 1;
            for (int j = 1; j < i; j++)
            {
                comb[i, j] = (comb[i - 1, j] + comb[i - 1, j - 1]) % mod;
            }
        }
        pSum = new int[11];
        for (int i = 9; i >= 0; i--)
        {
            pSum[i] = pSum[i + 1] + count[i];
        }

        memo = new long[10, target + 1, maxOdd + 1];
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j <= target; j++)
            {
                for (int k = 0; k <= maxOdd; k++)
                {
                    memo[i, j, k] = -1;
                }
            }
        }

        return (int)DP(0, 0, maxOdd);
    }

    long DP(int pos, int curr, int oddCount)
    {
        if (oddCount < 0 || pSum[pos] < oddCount || curr > target) return 0;

        if (pos > 9) return curr == target && oddCount == 0 ? 1 : 0;
        if (memo[pos, curr, oddCount] != -1) return memo[pos, curr, oddCount];
        int evenCount = pSum[pos] - oddCount;
        long ret = 0;
        for (int i = Math.Max(0, count[pos] - evenCount); i <= Math.Min(count[pos], oddCount); i++)
        {
            long ways = comb[oddCount, i] * comb[evenCount, count[pos] - i] % mod;
            ret = (ret + ways * DP(pos + 1, curr + i * pos, oddCount - i) % mod) % mod;
        }

        memo[pos, curr, oddCount] = ret;
        return ret;
    }
}