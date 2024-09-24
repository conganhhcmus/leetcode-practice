namespace Practice_1684;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        string allowed = "ab";
        string[] words = ["ad", "bd", "aaab", "baa", "badab"];
        Console.WriteLine(solution.CountConsistentStrings(allowed, words));
    }
    public int CountConsistentStrings(string allowed, string[] words)
    {
        int ans = 0;
        HashSet<char> charSet = [.. allowed.ToCharArray()];
        foreach (var word in words)
        {
            if (word.ToCharArray().All(charSet.Contains))
            {
                ans++;
            }
        }
        return ans;
    }
}