using System.Text;

public class Solution
{
    public int KthDigit(long k)
    {
        if (k < 10) return (int)k;
        k -= 9;
        long b = 1;
        long len = 2;
        //  b -> 10 * b have 9 * b cases
        // each case have 10 element with len => 10 * len
        // tot = 9L * b * 10L * len
        while (k > 9L * b * 10 * len)
        {
            k -= 9L * b * 10 * len;
            len++;
            b *= 10;
        }

        long blocks = (k - 1) / (10L * len);
        b += blocks;
        k -= blocks * 10L * len;

        StringBuilder sb = new();
        if (b % 2 == 0)
        {
            for (int i = 0; i < 10; i++)
            {
                sb.Append(10L * b + i);
            }
        }
        else
        {
            for (int i = 9; i >= 0; i--)
            {
                sb.Append(10L * b + i);
            }
        }
        return sb[(int)k - 1] - '0';
    }
}
