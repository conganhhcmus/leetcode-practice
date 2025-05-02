#if DEBUG
namespace Problems_2002_2;
#endif

public class Solution
{
    public int MaxProduct(string s)
    {
        int n = s.Length;
        int fullMask = (1 << n) - 1;
        int[] dp = new int[fullMask + 1];
        for (int mask = 0; mask <= fullMask; mask++)
        {
            dp[mask] = GetPalindromicSubsequenceSize(mask, s);
        }

        int ret = 0;
        for (int i = 0; i <= fullMask; i++)
        {
            for (int j = fullMask ^ i; j > 0; j = (j - 1) & (fullMask ^ i))
            {
                ret = Math.Max(ret, dp[i] * dp[j]);
            }
        }
        return ret;
    }

    int GetPalindromicSubsequenceSize(int mask, string s)
    {
        if (mask == 0) return 0;
        int left = 0, right = s.Length - 1;
        while (left <= right)
        {
            while (left <= right && (mask & (1 << left)) == 0) left++;
            while (left <= right && (mask & (1 << right)) == 0) right--;
            if (left <= right && s[left] != s[right]) return 0;
            left++;
            right--;
        }

        int count = 0;
        while (mask > 0)
        {
            count++;
            mask &= mask - 1;
        }
        return count;
    }
}