public class Solution
{
    public int CountSubstrings(string s)
    {
        // Transform:
        // "abba"
        // ->
        // "@#a#b#b#a#$"
        char[] t = new char[s.Length * 2 + 3];
        t[0] = '@';
        t[1] = '#';
        int idx = 2;
        foreach (char ch in s)
        {
            t[idx++] = ch;
            t[idx++] = '#';
        }
        t[idx++] = '$';
        int n = t.Length;
        int[] p = new int[n];
        int c = 0;
        int r = 0;
        int ans = 0;
        for (int i = 1; i < n - 1; i++)
        {
            // mirror postion of i
            int m = 2 * c - i;

            // if i is inside the current palindrome
            // copy as muck information as possible
            if (i < r) p[i] = Math.Min(r - i, p[m]);
            // try to expand
            while (t[i + p[i] + 1] == t[i - p[i] - 1]) p[i]++;

            // update the current rightmost palindrome
            if (i + p[i] > r)
            {
                c = i;
                r = i + p[i];
            }
            // number of original palindromes centered at i
            ans += (p[i] + 1) / 2;
        }
        return ans;
    }
}
