namespace Problem_567;

public class Solution
{
    public bool CheckInclusion(string s1, string s2)
    {
        if (s1.Length > s2.Length) return false;
        int[] s1arr = new int[26];
        int[] s2arr = new int[26];

        for (int i = 0; i < s1.Length; i++)
        {
            s1arr[s1[i] - 'a']++;
            s2arr[s2[i] - 'a']++;
        }

        for (int i = 0; i + s1.Length < s2.Length; i++)
        {
            if (IsMatch(s1arr, s2arr)) return true;
            s2arr[s2[i] - 'a']--;
            s2arr[s2[i + s1.Length] - 'a']++;
        }

        return IsMatch(s1arr, s2arr);
    }

    private bool IsMatch(int[] arr1, int[] arr2)
    {
        for (int i = 0; i < 26; i++)
        {
            if (arr1[i] != arr2[i]) return false;
        }

        return true;
    }
}