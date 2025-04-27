#if DEBUG
namespace Problems_28_2;
#endif

public class Solution
{
    public int StrStr(string haystack, string needle)
    {
        int[] lps = BuildLPS(needle);
        int i = 0, j = 0;
        while (i < haystack.Length)
        {
            if (haystack[i] == needle[j])
            {
                i++;
                j++;
                if (j == needle.Length) return i - j;
            }
            else
            {
                if (j != 0)
                {
                    j = lps[j - 1];
                }
                else
                {
                    i++;
                }
            }
        }
        return -1;
    }

    int[] BuildLPS(string pattern)
    {
        int n = pattern.Length;
        int[] lps = new int[n];
        int len = 0;
        int i = 1;
        while (i < n)
        {
            if (pattern[i] == pattern[len])
            {
                len++;
                lps[i] = len;
                i++;
            }
            else
            {
                if (len != 0)
                {
                    len = lps[len - 1];
                }
                else
                {
                    lps[i] = 0;
                    i++;
                }
            }
        }
        return lps;
    }
}