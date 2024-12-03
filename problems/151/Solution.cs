namespace Problem_151;

public class Solution
{
    public string ReverseWords(string s)
    {
        string[] words = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        return string.Join(" ", words.Reverse());
    }
}