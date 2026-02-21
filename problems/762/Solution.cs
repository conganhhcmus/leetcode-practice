public class Solution
{
    public int CountPrimeSetBits(int left, int right)
    {
        int ans = 0;
        for (int i = left; i <= right; i++)
        {
            if (IsPrime(CountBits(i))) ans++;
        }
        return ans;
    }

    bool IsPrime(int n)
    {
        if (n < 2) return false;
        for (int i = 2; i * i <= n; i += i % 2 + 1)
        {
            if (n % i == 0) return false;
        }
        return true;
    }

    int CountBits(int n)
    {
        int ans = 0;
        while (n > 0)
        {
            ans += n & 1;
            n >>= 1;
        }
        return ans;
    }
}