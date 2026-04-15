public class Solution
{
    public string ShortestPalindrome(string s)
    {
        if (s.Length <= 1)
            return s;
        string reverseStr = new(s.Reverse().ToArray());
        string combineStr = s + "#" + reverseStr;

        int[] kmp = KMP(combineStr);
        int palindromeLength = kmp[combineStr.Length - 1];
        string addStr = reverseStr[..(s.Length - palindromeLength)];
        return addStr + s;
    }

    private int[] KMP(string s)
    {
        var prefixTable = new int[s.Length];
        prefixTable[0] = 0;
        for (int i = 1; i < s.Length; i++)
        {
            int j = prefixTable[i - 1];
            while (j > 0 && s[i] != s[j])
            {
                j = prefixTable[j - 1];
            }
            if (s[i] == s[j])
            {
                j++;
            }
            prefixTable[i] = j;
        }

        return prefixTable;
    }
}

