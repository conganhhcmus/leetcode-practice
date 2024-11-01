using System.Text;

namespace Problem_1957;

public class Solution
{
    public static void Execute()
    {
        string s = "leeetcode";
        var solution = new Solution();
        Console.WriteLine(solution.MakeFancyString(s));
    }
    public string MakeFancyString(string s)
    {
        if (s.Length < 2) return s;
        StringBuilder ans = new(s[..2]);
        for (int i = 2; i < s.Length; i++)
        {
            if (s[i] != s[i - 1] || s[i] != s[i - 2])
            {
                ans.Append(s[i]);
            }
        }

        return ans.ToString();
    }
}