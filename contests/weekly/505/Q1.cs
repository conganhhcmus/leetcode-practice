public class Solution
{
    public int SumOfGoodIntegers(int n, int k)
    {
        int ans = 0;
        for (int x = 1; x <= n + k; x++)
        {
            if ((n & x) == 0 && Math.Abs(n - x) <= k) ans += x;
        }
        return ans;
    }
}
