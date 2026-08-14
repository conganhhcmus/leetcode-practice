public class Solution
{
    public int MaximumLengthSubstring(string s)
    {
        int n = s.Length;
        int ans = 0;
        int[] cnt = new int[26];
        for (int i = 0, j = 0; i < n; i++)
        {
            cnt[s[i] - 'a']++;
            while (j < i && cnt[s[i] - 'a'] > 2)
            {
                cnt[s[j] - 'a']--;
                j++;
            }
            ans = Math.Max(ans, i - j + 1);
        }
        return ans;
    }
}
