public class Solution
{
    public string RemoveOccurrences(string s, string part)
    {
        // https://www.geeksforgeeks.org/kmp-algorithm-for-pattern-searching/
        StringBuilder sb = new();
        int[] lps = ComputeLongestPrefixSuffix(part);
        int[] patternIndexes = new int[s.Length + 1];
        int patternIndex = 0;
        for (int i = 0; i < s.Length; i++)
        {
            sb.Append(s[i]);
            if (s[i] == part[patternIndex])
            {
                patternIndexes[sb.Length] = ++patternIndex;
                if (patternIndex == part.Length)
                {
                    sb.Remove(sb.Length - patternIndex, patternIndex);
                    patternIndex = patternIndexes[sb.Length];
                }
            }
            else
            {
                if (patternIndex != 0)
                {
                    patternIndex = lps[patternIndex - 1];
                    // Check again current index
                    i--;
                    sb.Remove(sb.Length - 1, 1);
                }
                else
                {
                    patternIndexes[sb.Length] = 0;
                }
            }
        }

        return sb.ToString();
    }

    private int[] ComputeLongestPrefixSuffix(string part)
    {
        int n = part.Length;
        int[] lps = new int[n];
        for (int i = 1, prefixLen = 0; i < n;)
        {
            if (part[i] == part[prefixLen])
            {
                lps[i] = ++prefixLen;
                i++;
            }
            else if (prefixLen != 0)
            {
                prefixLen = lps[prefixLen - 1];
            }
            else
            {
                lps[i] = 0;
                i++;
            }
        }

        return lps;
    }
}