#if DEBUG
namespace Problems_2523;
#endif

public class Solution
{
    public int[] ClosestPrimes(int left, int right)
    {
        bool[] primes = new bool[right + 1];
        Array.Fill(primes, true);
        primes[0] = primes[1] = false;
        for (int i = 2; i <= right; i++)
        {
            if (!primes[i]) continue;
            for (int j = i * 2; j <= right; j += i)
            {
                primes[j] = false;
            }
        }
        int min = int.MaxValue, num1 = -1, num2 = -1;
        int prev = -1;
        for (int i = left; i <= right; i++)
        {
            if (primes[i])
            {
                if (prev != -1 && min > i - prev)
                {
                    num1 = prev;
                    num2 = i;
                    min = i - prev;
                }
                prev = i;
            }
        }
        return [num1, num2];
    }
}