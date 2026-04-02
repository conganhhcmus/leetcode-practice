public class Solution
{
    public int AlmostPalindromic(string s)
    {
        int max = 0;
        int n = s.Length;
        for (int i = 0; i < n; i++)
        {
            // pick s[i] at the middle
            max = Math.Max(max, Calc(s, i, i));

            // pick s[i] & s[i-1] is middle
            if (i > 0 && s[i - 1] == s[i])
            {
                max = Math.Max(max, Calc(s, i - 1, i));
            }
        }

        return Math.Min(n, max);
    }

    int Calc(string s, int l, int r)
    {
        int n = s.Length;
        int max = 0;
        var (l1, r1) = GetMax(s, l, r);
        max = Math.Max(max, r1 - l1 + 1);
        if (l1 > 0)
        {
            var (l2, r2) = GetMax(s, l1 - 1, r1);
            max = Math.Max(max, r2 - l2 + 1);
        }

        if (r1 + 1 < n)
        {
            var (l2, r2) = GetMax(s, l1, r1 + 1);
            max = Math.Max(max, r2 - l2 + 1);
        }
        return max;
    }

    (int, int) GetMax(string s, int l, int r)
    {
        int n = s.Length;
        while (l > 0 && r + 1 < n && s[l - 1] == s[r + 1])
        {
            l--;
            r++;
        }

        return (l, r);
    }
}