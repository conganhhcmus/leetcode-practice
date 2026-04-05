public class Solution
{
    public int MirrorFrequency(string s)
    {
        Dictionary<char, int> freq = [];
        foreach (char c in s)
        {
            freq[c] = freq.GetValueOrDefault(c, 0) + 1;
        }
        int tot = 0;
        for (char c = 'a'; c <= 'z'; c++)
        {
            int a = freq.GetValueOrDefault(c, 0);
            int b = freq.GetValueOrDefault((char)('z' - c + 'a'), 0);
            tot += Math.Abs(a - b);
        }
        for (char c = '0'; c <= '9'; c++)
        {
            int a = freq.GetValueOrDefault(c, 0);
            int b = freq.GetValueOrDefault((char)('9' - c + '0'), 0);
            tot += Math.Abs(a - b);
        }
        return tot / 2;
    }
}