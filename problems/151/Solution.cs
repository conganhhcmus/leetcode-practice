namespace Problem_151;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        string s = "the sky is blue";
        Console.WriteLine(solution.ReverseWords(s));
    }
    public string ReverseWords(string s)
    {
        string[] words = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        return string.Join(" ", words.Reverse());
    }
}