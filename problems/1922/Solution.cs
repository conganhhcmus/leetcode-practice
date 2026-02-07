public class Solution
{
    int mod = (int)1e9 + 7;
    public int CountGoodNumbers(long n)
    {
        long evenCount = (n + 1) >> 1;
        long oddCount = n - evenCount;
        long ret = PermutationEven(evenCount) * PermutationOdd(oddCount) % mod;
        return (int)ret;
    }

    long PermutationEven(long n)
    {
        if (n == 0) return 1;
        long ways = 5; // 0 2 4 6 8
        return FastPower(ways, n);
    }

    long PermutationOdd(long n)
    {
        if (n == 0) return 1;
        long ways = 4; // 2 3 5 7
        return FastPower(ways, n);
    }

    long FastPower(long a, long b)
    {
        long ans = 1;
        while (b > 0)
        {
            if ((b & 1) > 0)
            {
                ans = ans * a % mod;
            }
            a = a * a % mod;
            b >>= 1;
        }
        return ans;
    }
}