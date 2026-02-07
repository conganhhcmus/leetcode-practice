public class Solution
{
    public int PrefixCount(string[] words, string pref)
    {
        int ans = 0, n = words.Length;
        for (int i = 0; i < n; i++)
        {
            if (pref.Length <= words[i].Length && words[i][..pref.Length] == pref) ans++;
        }
        return ans;
    }
}