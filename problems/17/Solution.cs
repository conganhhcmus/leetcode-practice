using System.Text;

namespace Problem_17;

public class Solution
{
    public static void Execute()
    {
        string digits = "23";
        var solution = new Solution();
        var res = solution.LetterCombinations(digits);
        Console.WriteLine($"[{string.Join(",", res)}]");
    }
    public IList<string> LetterCombinations(string digits)
    {
        if (digits.Length == 0) return [];
        var map = new Dictionary<char, string>{
            {'2', "abc"},
            {'3', "def"},
            {'4', "ghi"},
            {'5', "jkl"},
            {'6', "mno"},
            {'7', "pqrs"},
            {'8', "tuv"},
            {'9', "wxyz"},
        };
        List<string> result = [];
        StringBuilder sb = new();

        void BackTracking(int index)
        {
            if (index == digits.Length)
            {
                result.Add(sb.ToString());
                return;
            }

            foreach (char c in map[digits[index]])
            {
                sb.Append(c);
                BackTracking(index + 1);
                sb.Length--;
            }
        }
        BackTracking(0);
        return result;
    }
}