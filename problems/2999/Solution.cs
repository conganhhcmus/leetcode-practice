#if DEBUG
namespace Problems_2999;
#endif

public class Solution
{
    public long NumberOfPowerfulInt(long start, long finish, int limit, string s)
    {
        string start_ = (start - 1).ToString();
        string finish_ = finish.ToString();
        return Calculate(finish_, s, limit) - Calculate(start_, s, limit);
    }

    private long Calculate(string x, string s, int limit)
    {
        if (x.Length < s.Length) return 0;
        if (x.Length == s.Length) return string.Compare(x, s) >= 0 ? 1 : 0;

        string suffix = x.Substring(x.Length - s.Length);
        long count = 0;
        int preLen = x.Length - s.Length;

        for (int i = 0; i < preLen; i++)
        {
            int digit = x[i] - '0';
            if (limit < digit)
            {
                count += (long)Math.Pow(limit + 1, preLen - i);
                return count;
            }
            count += digit * (long)Math.Pow(limit + 1, preLen - 1 - i);
        }
        if (string.Compare(suffix, s) >= 0) count++;
        return count;
    }
}