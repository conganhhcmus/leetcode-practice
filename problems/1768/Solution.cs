public class Solution
{
    public string MergeAlternately(string word1, string word2)
    {
        string ans = "";
        int minLength = int.Min(word1.Length, word2.Length);

        for (int i = 0; i < minLength; i++)
        {
            ans += "" + word1[i] + word2[i];
        }

        for (int i = minLength; i < word1.Length; i++)
        {
            ans += "" + word1[i];
        }

        for (int i = minLength; i < word2.Length; i++)
        {
            ans += "" + word2[i];
        }

        return ans;
    }
}