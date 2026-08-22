public class Solution
{
    public bool CheckDivisibility(int n)
    {
        int sum = 0;
        int product = 1;
        int x = n;
        while (x > 0)
        {
            int d = x % 10;
            sum += d;
            product *= d;
            x /= 10;
        }
        return n % (sum + product) == 0;
    }
}
