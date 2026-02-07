public class Solution
{
    public bool IsIsomorphic(string s, string t)
    {
        if (s.Length != t.Length) return false;
        int[] freqS = new int[200];
        int[] freqT = new int[200];
        for (int i = 0; i < s.Length; i++)
        {
            if (freqS[s[i]] != freqT[t[i]]) return false;
            freqS[s[i]] = i + 1;
            freqT[t[i]] = i + 1;
        }

        return true;
    }
}