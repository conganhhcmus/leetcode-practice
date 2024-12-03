namespace Problem_3;

public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        var freq = new Dictionary<char, int>();
        int max = Math.Min(1, s.Length);

        for (int l = 0; l < s.Length; l++)
        {
            for (int r = l; r < s.Length; r++)
            {
                if (freq.TryGetValue(s[r], out int value) && value > 0)
                {
                    freq.Clear();
                    break;
                }

                freq[s[r]] = value + 1;
                max = r - l + 1 > max ? r - l + 1 : max;
            }

        }
        return max;
    }
}