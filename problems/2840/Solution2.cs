public class Solution
{
    public bool CheckStrings(string s1, string s2)
    {
        int[] count = new int[52];
        int n = s1.Length;
        for (int i = 0; i < n; i++)
        {
            int offset = (i & 1) * 26;
            count[offset + s1[i] - 'a']++;
            count[offset + s2[i] - 'a']--;
        }
        for (int i = 0; i < 52; i++)
        {
            if (count[i] != 0) return false;
        }
        return true;
    }
}