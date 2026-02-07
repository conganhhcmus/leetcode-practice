public class Solution
{
    public int MaxProduct(string s)
    {
        // n = 12
        // 2^12 = 4096
        int n = s.Length;
        int fullMask = (1 << n) - 1;
        bool[] dp = new bool[fullMask + 1];
        int[] map = new int[fullMask + 1];
        // O(n * 12) ~ O(n)
        for (int mask = 0; mask <= fullMask; mask++)
        {
            dp[mask] = IsPalindromicSubsequence(mask, s);
            map[mask] = CountSetBit(mask);
        }
        int ret = 0;
        // O(n*(n-1)/2) ~ O(n^2)
        for (int i = 0; i <= fullMask; i++) // 4096
        {
            for (int j = i + 1; j <= fullMask; j++) // 4096
            {
                if (dp[i] && dp[j] && (i & j) == 0)
                {
                    ret = Math.Max(ret, map[i] * map[j]);
                }
            }
        }
        return ret;
    }

    int CountSetBit(int mask)
    {
        int count = 0;
        while (mask > 0)
        {
            count++;
            mask &= mask - 1;
        }
        return count;
    }

    bool IsPalindromicSubsequence(int mask, string s)
    {
        int left = 0, right = s.Length - 1;
        while (left <= right)
        {
            while (left <= right && (mask & (1 << left)) == 0) left++;
            while (left <= right && (mask & (1 << right)) == 0) right--;
            if (left <= right && s[left] != s[right]) return false;
            left++;
            right--;
        }
        return true;
    }
}