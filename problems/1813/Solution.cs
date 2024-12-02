namespace Problem_1813;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        string sentence1 = "A B C D C B";
        string sentence2 = "A B C B";
        Console.WriteLine(solution.AreSentencesSimilar(sentence1, sentence2));
    }

    public bool AreSentencesSimilar(string sentence1, string sentence2)
    {
        if (sentence1 == sentence2) return true;

        string[] word1s = sentence1.Split(' ');
        string[] word2s = sentence2.Split(' ');

        int suffix = 0;
        int prefix = 0;
        int minLen = Math.Min(word1s.Length, word2s.Length);
        for (int i = 0; i < minLen; i++)
        {
            if (word1s[i] != word2s[i]) break;
            prefix++;
        }

        for (int i = 1; i <= minLen; i++)
        {
            if (word1s[^i] != word2s[^i]) break;
            suffix++;
        }

        return prefix + suffix >= minLen || prefix == minLen || suffix == minLen;
    }
}