public class Solution
{
    public int MaxDigitRange(int[] nums)
    {
        int max = 0;
        int ans = 0;
        foreach (int x in nums)
        {
            int v = DigitRange(x);
            if (v > max)
            {
                max = v;
                ans = x;
            }
            else if (v == max)
            {
                ans += x;
            }
        }
        return ans;

        int DigitRange(int n)
        {
            int min = 9, max = 0;
            while (n > 0)
            {
                int d = n % 10;
                n /= 10;
                if (min > d) min = d;
                if (max < d) max = d;
            }
            return Math.Max(0, max - min);
        }
    }
}
