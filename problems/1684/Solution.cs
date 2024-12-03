namespace Problem_1684;

public class Solution
{
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