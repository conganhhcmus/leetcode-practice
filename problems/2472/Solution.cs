public class Solution
{
    public int MaxPalindromes(string s, int k)
    {
        int n = s.Length;
        memo = new int[n];
        Array.Fill(memo, -1);
        return DP(0, s, k);
    }

    int[] memo;

    int DP(int pos, string s, int k)
    {
        int n = s.Length;
        if (pos >= n) return 0;
        if (n - pos < k) return 0;
        if (memo[pos] != -1) return memo[pos];
        int ans = DP(pos + 1, s, k);
        for (int i = pos + k - 1; i < n; i++)
        {
            if (IsPalindrome(s, pos, i))
            {
                ans = Math.Max(ans, 1 + DP(i + 1, s, k));
                break;
            }
        }

        return memo[pos] = ans;
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