public class Solution
{
    public int NumOfStrings(string[] patterns, string word)
    {
        HashSet<string> seen = [];
        int n = word.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                seen.Add(word.Substring(i, j - i + 1));
            }
        }
        int ans = 0;
        foreach (string w in patterns)
        {
            if (seen.Contains(w)) ans++;
        }
        return ans;
    }
}
