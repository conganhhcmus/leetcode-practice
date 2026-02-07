public class Solution
{
    public int LongestPalindrome(string s, string t)
    {
        string s2 = new([.. t.Reverse()]);
        int ret = 0;
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = 0; j < s2.Length; j++)
            {
                ret = Math.Max(ret, LongestPalindrome(s, s2, i, j));
            }
        }
        return ret;
    }

    int LongestPalindrome(string s1, string s2, int i, int j)
    {
        int ret = 0;
        while (i < s1.Length && j < s2.Length && s1[i] == s2[j])
        {
            ret += 2;
            i++;
            j++;
        }
        int extra = Math.Max(GetExtra(s1, i), GetExtra(s2, j));
        return ret + extra;
    }

    int GetExtra(string s, int pos)
    {
        int ret = 0;
        for (int i = s.Length - 1; i >= pos; i--)
        {
            if (IsPalindrome(s, pos, i))
            {
                ret = i - pos + 1;
                break;
            }
        }
        return ret;
    }

    bool IsPalindrome(string s, int start, int end)
    {
        while (start < end)
        {
            if (s[start] != s[end]) return false;
            start++;
            end--;
        }
        return true;
    }
}