public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length) return false;
        int[] arr1 = new int[256];
        int[] arr2 = new int[256];
        for (int i = 0; i < s.Length; i++)
        {
            arr1[s[i]]++;
            arr2[t[i]]++;
        }
        for (int i = 0; i < 256; i++)
        {
            if (arr1[i] != arr2[i]) return false;
        }
        return true;
    }
}