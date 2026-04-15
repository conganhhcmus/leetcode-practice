public class Solution
{
    public int CharacterReplacement(string s, int k)
    {
        int n = s.Length;
        int ans = 0;
        int[] freq = new int[26];
        for (int i = 0, j = 0; i < n; i++)
        {
            freq[s[i] - 'A']++;
            while (j < i && !Ok(freq, k))
            {
                freq[s[j] - 'A']--;
                j++;
            }
            ans = Math.Max(ans, i - j + 1);
        }
        return ans;
    }

    bool Ok(int[] freq, int k)
    {
        int t = 0;
        int m = 0;
        for (int i = 0; i < 26; i++)
        {
            t += freq[i];
            if (m < freq[i])
                m = freq[i];
        }
        return (t - m) <= k;
    }
}
