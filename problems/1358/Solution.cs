#if DEBUG
namespace Problems_1358;
#endif

public class Solution
{
    public int NumberOfSubstrings(string s)
    {
        int count = 0;
        int n = s.Length, l = 0, r = 0;
        int[] freq = new int[3];
        while (r < n)
        {
            // insert r
            freq[s[r] - 'a']++;
            while (l < n && Ok(freq))
            {
                count += n - r;
                freq[s[l] - 'a']--;
                l++;
            }
            r++;
        }
        return count;
    }

    bool Ok(int[] freq)
    {
        for (int i = 0; i < freq.Length; i++)
        {
            if (freq[i] == 0) return false;
        }
        return true;
    }
}