public class Solution
{
    public double MyPow(double x, int n)
    {
        double ans = 1;
        if (n < 0) x = 1 / x;
        long step = Math.Abs((long)n);
        while (step > 0)
        {
            if ((step & 1) > 0)
            {
                ans *= x;
            }
            x *= x;
            step >>= 1;
        }

        return ans;
    }
}