#if DEBUG
namespace Problems_151;
#endif

public class Solution
{
    public string ReverseWords(string s)
    {
        string[] words = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        return string.Join(" ", words.Reverse());
    }
}