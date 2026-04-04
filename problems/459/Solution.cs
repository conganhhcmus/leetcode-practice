public class Solution
{
    public bool RepeatedSubstringPattern(string s)
    {
        int n = s.Length;
        for (int len = 1; len <= n / 2; len++)
        {
            if (n % len != 0) continue;
            if (IsOk(s, len)) return true;
        }
        return false;
    }

    bool IsOk(string s, int len)
    {
        int n = s.Length;
        for (int i = 0; i + len < n; i++)
        {
            if (s[i] != s[i + len]) return false;
        }
        return true;
    }
}