public class Solution
{
    public bool JudgeSquareSum(int c)
    {
        long a = 0, b = (long)Math.Sqrt(c);
        while (a <= b)
        {
            long s = a * a + b * b;
            if (s == c) return true;
            if (s > c) b--;
            else a++;
        }

        return false;
    }
}