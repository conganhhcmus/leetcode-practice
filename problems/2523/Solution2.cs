#if DEBUG
namespace Problems_2523_2;
#endif

public class Solution
{
    public int[] ClosestPrimes(int left, int right)
    {
        int prevPrime = -1, closeA = -1, closeB = -1;
        int minDiff = int.MaxValue;
        for (int candidate = left; candidate <= right; candidate++)
        {
            if (IsPrime(candidate))
            {
                if (prevPrime != -1)
                {
                    int diff = candidate - prevPrime;
                    if (diff < minDiff)
                    {
                        minDiff = diff;
                        closeA = prevPrime;
                        closeB = candidate;
                    }
                    if (minDiff == 2 || minDiff == 1) return [closeA, closeB];
                }
                prevPrime = candidate;
            }
        }
        return [closeA, closeB];
    }

    bool IsPrime(int num)
    {
        if (num < 2) return false;
        if (num == 2) return true;
        if (num % 2 == 0) return false;
        for (int i = 3; i * i <= num; i += 2)
        {
            if (num % i == 0) return false;
        }
        return true;
    }
}