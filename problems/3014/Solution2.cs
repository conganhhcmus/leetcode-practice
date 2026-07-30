public class Solution
{
    public int MinimumPushes(string word)
    {
        int[] cnt = new int[26];
        int ans = 0;
        int count = 0;
        foreach (char c in word)
        {
            if (cnt[c - 'a'] == 0)
            {
                cnt[c - 'a'] = (count / 8) + 1;
                count++;
            }
            ans += cnt[c - 'a'];
        }
        return ans;
    }
}
