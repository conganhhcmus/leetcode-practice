#if DEBUG
namespace Problems_2222_4;
#endif

public class Solution
{
    public long NumberOfWays(string s)
    {
        int n = s.Length;
        int count0 = 0, count1 = 0;
        foreach (char c in s)
        {
            count0 += '1' - c;
            count1 += c - '0';
        }
        int curr1 = s[0] - '0', curr0 = '1' - s[0];
        long ret = 0;
        for (int i = 1; i < n; i++)
        {
            if (s[i] == '0')
            {
                ret += 1L * curr1 * (count1 - curr1);
                curr0++;
            }
            else
            {
                ret += 1L * curr0 * (count0 - curr0);
                curr1++;
            }
        }
        return ret;
    }
}