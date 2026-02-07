public class Solution
{
    public int[] ClosestPrimes(int left, int right)
    {
        bool[] sievePrimes = new bool[right + 1];
        Array.Fill(sievePrimes, true);
        sievePrimes[0] = sievePrimes[1] = false;
        for (int i = 2; i <= right; i++)
        {
            if (!sievePrimes[i]) continue;
            for (int j = i * 2; j <= right; j += i)
            {
                sievePrimes[j] = false;
            }
        }

        int num1 = -1, num2 = -1, min = int.MaxValue, prev = -1;
        for (int i = left; i <= right; i++)
        {
            if (!sievePrimes[i]) continue;
            if (prev != -1)
            {
                int diff = i - prev;
                if (diff < min)
                {
                    min = diff;
                    num1 = prev;
                    num2 = i;
                }
                if (min == 2 || min == 1) return [num1, num2];
            }

            prev = i;
        }
        return [num1, num2];
    }
}