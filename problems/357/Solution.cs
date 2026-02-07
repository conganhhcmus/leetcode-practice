public class Solution
{
    public int CountNumbersWithUniqueDigits(int n)
    {
        // 1 -> n digits
        return DP(0, true, "", n);
    }

    int DP(int pos, bool isLeadingZero, string num, int n)
    {
        if (pos >= n) return 1;

        int ret = 0;
        for (char d = '0'; d <= '9'; d++)
        {
            bool newIsLeadingZero = isLeadingZero && d == '0';
            if (newIsLeadingZero)
            {
                ret += DP(pos + 1, true, num, n);
            }
            else
            {
                if (!num.Contains(d))
                {
                    ret += DP(pos + 1, newIsLeadingZero, num + d, n);
                }
            }
        }
        return ret;
    }
}