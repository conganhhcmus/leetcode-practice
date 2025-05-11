#if DEBUG
namespace Problems_409;
#endif

public class Solution
{
    public int LongestPalindrome(string s)
    {
        int[] freq = new int[256];
        foreach (char c in s)
        {
            freq[c]++;
        }
        int ret = 0;
        bool extra = false;
        for (int i = 0; i < 256; i++)
        {
            ret += 2 * (freq[i] / 2);
            if (freq[i] % 2 != 0) extra = true;
        }
        if (extra) ret++;
        return ret;
    }
}