namespace Problem_214;

public class Solution
{
    public string ShortestPalindrome(string s)
    {
        return KMP(s);
    }

    private string KMP(string s)
    {
        if (s.Length <= 1) return s;

        string reverseStr = new(s.Reverse().ToArray());
        string combineStr = s + "#" + reverseStr;

        var prefixTable = new int[combineStr.Length];
        prefixTable[0] = 0;
        for (int i = 1; i < combineStr.Length; i++)
        {
            int len = prefixTable[i - 1];
            while (len > 0 && combineStr[i] != combineStr[len])
            {
                len = prefixTable[len - 1];
            }
            if (combineStr[i] == combineStr[len])
            {
                len++;
            }
            prefixTable[i] = len;
        }

        Console.WriteLine($"[{string.Join(",", combineStr.ToCharArray())}]");
        Console.WriteLine($"[{string.Join(",", prefixTable)}]");
        int palindromeLength = prefixTable[combineStr.Length - 1];
        string addStr = reverseStr[..(s.Length - palindromeLength)];

        return addStr + s;
    }
}