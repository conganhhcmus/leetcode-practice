public class Solution
{
    public bool IsMatch(string s, string p)
    {
        int i = 0, j = 0;
        int star = -1;
        int m = -1;
        while (i < s.Length)
        {
            if (j < p.Length && (p[j] == '?' || p[j] == s[i]))
            {
                i++;
                j++;
                continue;
            }
            if (j < p.Length && p[j] == '*') // * = empty
            {
                star = j;
                j++;
                m = i;
                continue;
            }
            if (star >= 0) // * != empty
            {
                j = star + 1;
                i = m + 1;
                m++;
                continue;
            }
            return false;
        }
        while (j < p.Length && p[j] == '*')
        {
            j++;
        }
        return j == p.Length;
    }
}