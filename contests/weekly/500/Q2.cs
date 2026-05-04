public class Solution
{
    public int SumOfPrimesInRange(int n)
    {
        int m = 0;
        int t = n;
        while (t > 0)
        {
            m = m * 10 + t % 10;
            t /= 10;
        }
        int MAX = Math.Max(n, m);
        bool[] isPrime = new bool[MAX + 1];
        Array.Fill(isPrime, true);
        isPrime[0] = isPrime[1] = false;
        for (int i = 2; i <= MAX; i++)
        {
            if (isPrime[i])
            {
                for (int j = 2 * i; j <= MAX; j += i)
                {
                    isPrime[j] = false;
                }
            }
        }
        int sum = 0;
        for (int i = Math.Min(n, m); i <= Math.Max(n, m); i++)
        {
            if (isPrime[i]) sum += i;
        }
        return sum;
    }
}
