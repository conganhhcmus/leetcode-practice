namespace Problem_1657;

public class Solution
{
    public bool CloseStrings(string word1, string word2)
    {
        if (word1.Length != word2.Length) return false;

        var charCount1 = new int[26];
        var charCount2 = new int[26];
        for (int i = 0; i < word1.Length; i++)
        {
            charCount1[word1[i] - 'a']++;
            charCount2[word2[i] - 'a']++;
        }

        for (int i = 0; i < charCount1.Length; i++)
        {
            if ((charCount1[i] == 0 && charCount2[i] != 0)
            || (charCount1[i] != 0 && charCount2[i] == 0))
                return false;
        }

        Array.Sort(charCount1);
        Array.Sort(charCount2);

        for (int i = 0; i < charCount1.Length; i++)
        {
            if (charCount1[i] != charCount2[i]) return false;
        }

        return true;
    }
}