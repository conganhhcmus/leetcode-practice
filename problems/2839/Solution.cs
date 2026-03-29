public class Solution
{
    public bool CanBeEqual(string s1, string s2)
    {
        int[] count = new int[26];
        for (int i = 0; i < 4; i += 2)
        {
            count[s1[i] - 'a']++;
            count[s2[i] - 'a']--;
        }
        for (int i = 0; i < 26; i++)
        {
            if (count[i] != 0) return false;
        }

        for (int i = 1; i < 4; i += 2)
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