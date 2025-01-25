namespace Library;

public class Prime
{
    // Sieve Prime Factorization
    public static int[] BuildSpf(int maxValue)
    {
        int[] spf = new int[maxValue + 1];
        for (int i = 2; i <= maxValue; i++) spf[i] = i;
        for (int i = 2; i <= maxValue; i++)
        {
            if (spf[i] == i)
            {
                for (int j = 2 * i; j <= maxValue; j += i)
                {
                    if (spf[j] == j) spf[j] = i;
                }
            }
        }

        return spf;
    }

    public static List<int> GetPrimeFactors(int num, int[] spf)
    {
        List<int> factors = [];
        while (num > 1)
        {
            int prime = spf[num];
            factors.Add(prime);
            num /= prime;
        }

        return factors;
    }
}