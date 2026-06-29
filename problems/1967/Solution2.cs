public class Solution
{
    public int NumOfStrings(string[] patterns, string word)
    {
        int ans = 0;
        foreach (string w in patterns)
        {
            if (word.Contains(w)) ans++;
        }
        return ans;
    }
}
