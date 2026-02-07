public class Solution
{
    public int Divide(int dividend, int divisor)
    {
        long ans = 0;
        bool isNegative = (dividend < 0) ^ (divisor < 0);
        long ldividend = Math.Abs((long)dividend);
        long ldivisor = Math.Abs((long)divisor);
        for (int i = 31; i >= 0; i--)
        {
            if ((ldivisor << i) <= ldividend)
            {
                ldividend -= ldivisor << i;
                ans |= 1L << i;
            }
        }

        if (isNegative) ans = -ans;
        return (int)Math.Min(int.MaxValue, Math.Max(int.MinValue, ans));
    }
}