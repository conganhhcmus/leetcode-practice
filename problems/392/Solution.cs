namespace Problem_392;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        string s = "abc", t = "ahbgdc";
        Console.WriteLine(solution.IsSubsequence(s, t));
    }
    public bool IsSubsequence(string s, string t)
    {
        int left = 0;
        int right = 0;
        while (left < s.Length && right < t.Length)
        {
            if (s[left] == t[right]) left++;
            right++;
        }

        return left == s.Length;
    }
}