#if DEBUG
namespace Weekly_443_Q2;
#endif

public class Solution
{
    public int LongestPalindrome(string s, string t)
    {
        int n1 = s.Length, n2 = t.Length;
        int ret = 1;
        for (int i = 0; i < n1; i++)
        {
            for (int j = i; j < n1; j++)
            {
                if (IsPalindrome(s.Substring(i, j - i + 1)))
                {
                    ret = Math.Max(ret, j - i + 1);
                }
                for (int k = 0; k < n2; k++)
                {
                    for (int l = k; l < n2; l++)
                    {
                        if (IsPalindrome(t.Substring(k, l - k + 1)))
                        {
                            ret = Math.Max(ret, l - k + 1);
                        }
                        if (IsPalindrome(s.Substring(i, j - i + 1) + t.Substring(k, l - k + 1)))
                        {
                            ret = Math.Max(ret, j - i + 1 + l - k + 1);
                        }
                    }
                }
            }
        }
        return ret;
    }

    bool IsPalindrome(string s)
    {
        for (int i = 0; i <= s.Length / 2; i++)
        {
            if (s[i] != s[s.Length - 1 - i]) return false;
        }
        return true;
    }
}