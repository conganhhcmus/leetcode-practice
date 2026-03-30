public class Solution
{
    public bool CheckStrings(string s1, string s2)
    {
        int[] count = new int[26];
        int n = s1.Length;
        for (int i = 0; i < n; i += 2)
        {
            count[s1[i] - 'a']++;
            count[s2[i] - 'a']--;
        }
        for (int i = 0; i < 26; i++)
        {
            if (count[i] != 0) return false;
        }
        for (int i = 1; i < n; i += 2)
        {
            count[s1[i] - 'a']++;
            count[s2[i] - 'a']--;
        }
        for (int i = 0; i < 26; i++)
        {
            if (count[i] != 0) return false;
        }
        return true;
    }
}