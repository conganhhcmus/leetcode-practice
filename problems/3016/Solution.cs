public class Solution
{
    public int MinimumPushes(string word)
    {
        int[] cnt = new int[26];
        foreach (char c in word) cnt[c - 'a']++;
        Array.Sort(cnt, (a, b) => b - a);
        int ans = 0;
        for (int i = 0; i < 26; i++)
        {
            ans += cnt[i] * ((i + 8) / 8);
        }
        return ans;
    }
}
