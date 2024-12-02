namespace Problem_1455;

using Helpers;
using Structures;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        string sentence = "i love eating burger";
        string searchWord = "burg";
        Console.WriteLine(solution.IsPrefixOfWord(sentence, searchWord));
    }
    public int IsPrefixOfWord(string sentence, string searchWord)
    {
        string[] words = sentence.Split(" ");
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].StartsWith(searchWord)) return i + 1;
        }
        return -1;
    }
}