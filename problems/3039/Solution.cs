public class Solution
{
    public string LastNonEmptyString(string s)
    {
        int n = s.Length;
        int[] count = new int[26];
        foreach (char c in s)
        {
            count[c - 'a']++;
        }
        int max = 0;
        for (int i = 0; i < 26; i++)
        {
            if (max < count[i]) max = count[i];
        }
        for (int i = 0; i < 26; i++)
        {
            count[i] -= max - 1;
        }
        StringBuilder sb = new();
        for (int i = n - 1; i >= 0; i--)
        {
            if (count[s[i] - 'a'] > 0)
            {
                sb.Insert(0, s[i]);
                count[s[i] - 'a']--;
            }
        }

        return sb.ToString();
    }
}