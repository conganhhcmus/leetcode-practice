public class Solution
{
    public int MinimumLength(string s)
    {
        int[] chars = new int[26];
        foreach (char c in s) chars[c - 'a']++;
        int ans = 0;
        for (int i = 0; i < 26; i++)
        {
            while (chars[i] >= 3) chars[i] -= 2;
            ans += chars[i];
        }
        return ans;
    }
}