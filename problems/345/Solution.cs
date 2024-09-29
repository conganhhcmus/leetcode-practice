namespace Problem_345;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        string s = "leetcode";
        Console.WriteLine(solution.ReverseVowels(s));
    }
    public string ReverseVowels(string s)
    {
        char[] vowels = ['a', 'e', 'i', 'o', 'u'];
        char[] chars = s.ToCharArray();
        List<int> dp = [];
        for (int i = 0; i < chars.Length; i++)
        {
            if (vowels.Contains(char.ToLower(chars[i])))
            {
                dp.Add(i);
            }
        }

        for (int i = 0; i < dp.Count / 2; i++)
        {
            (chars[dp[dp.Count - 1 - i]], chars[dp[i]]) = (chars[dp[i]], chars[dp[dp.Count - 1 - i]]);
        }

        return string.Join("", chars);
    }
}