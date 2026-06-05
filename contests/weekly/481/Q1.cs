public class Solution
{
    public int MirrorDistance(int n)
    {
        int Reverse(int a)
        {
            int b = 0;
            while (a > 0)
            {
                b = b * 10 + a % 10;
                a /= 10;
            }
            return b;
        }
        return Math.Abs(n - Reverse(n));
    }
}
