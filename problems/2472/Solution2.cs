public class Solution
{
    public int MaxPalindromes(string s, int k)
    {
        int n = s.Length;
        int ans = 0;
        for (int lo = 0; lo <= n - k; lo++)
        {
            // case 1: min length
            int hi = lo + k - 1;
            if (hi < n && IsPalindrome(s, lo, hi))
            {
                ans++;
                lo = hi;
                continue;
            }

            // case 2: odd is case 1 is even, vice versa
            hi = lo + k;
            if (hi < n && IsPalindrome(s, lo, hi))
            {
                ans++;
                lo = hi;
            }
        }
        return ans;
    }

    bool IsPalindrome(string s, int st, int ed)
    {
        while (st < ed)
        {
            if (s[st] != s[ed]) return false;
            st++;
            ed--;
        }
        return true;
    }
}