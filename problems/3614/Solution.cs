public class Solution
{
    public char ProcessStr(string s, long k)
    {
        int n = s.Length;
        long len = 0;
        for (int i = 0; i < n; i++)
        {
            if (s[i] >= 'a' && s[i] <= 'z') len++;
            else if (s[i] == '*') len = Math.Max(0, len - 1);
            else if (s[i] == '#') len *= 2L;
        }
        if (k >= len) return '.';
        for (int i = n - 1; i >= 0; i--)
        {
            char c = s[i];
            if (c == '#')
            {
                len /= 2;
                k %= len;
            }
            else if (c == '*') len++;
            else if (c == '%') k = len - 1 - k;
            else
            {
                if (k == len - 1) return c;
                len--;
            }
        }
        return '.';
    }
}
