public class Solution
{
    public int LargestPrime(int n)
    {
        int[] spf = new int[n + 1];
        Array.Fill(spf, -1);
        spf[0] = 0;
        spf[1] = 1;
        for (int i = 2; i <= n; i++)
        {
            if (spf[i] == -1)
            {
                for (int j = 2 * i; j <= n; j += i)
                {
                    if (spf[j] == -1) spf[j] = i;
                }
            }
        }
        List<int> primes = [];
        for (int i = 2; i <= n; i++)
        {
            if (spf[i] == -1) primes.Add(i);
        }
        int ans = 0;
        int m = primes.Count;
        int sum = 0;
        for (int i = 0; i < m; i++)
        {
            sum += primes[i];
            if (sum > n) break;
            if (spf[sum] == -1) ans = Math.Max(ans, sum);
        }
        return ans;
    }
}
