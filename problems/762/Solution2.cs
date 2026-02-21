public class Solution
{
    int bitMax = 32;
    bool[] isPrime;
    int[,,] dp;
    public int CountPrimeSetBits(int left, int right)
    {
        isPrime = new bool[bitMax];
        Array.Fill(isPrime, true);
        isPrime[0] = isPrime[1] = false;
        for (int i = 2; i < bitMax; i++)
        {
            if (!isPrime[i]) continue;
            int j = 2 * i;
            while (j < bitMax)
            {
                isPrime[j] = false;
                j += i;
            }
        }

        return Solve(right) - Solve(left - 1);
    }

    int Solve(int n)
    {
        if (n < 0) return 0;
        dp = new int[bitMax, bitMax, 2];
        for (int i = 0; i < bitMax; i++)
        {
            for (int j = 0; j < bitMax; j++)
            {
                for (int k = 0; k < 2; k++)
                {
                    dp[i, j, k] = -1;
                }
            }
        }
        string bits = "";
        while (n > 0)
        {
            bits = (n & 1).ToString() + bits;
            n >>= 1;
        }
        while (bits.Length < bitMax)
        {
            bits = "0" + bits;
        }
        return DP(bits, 0, 0, 1);
    }

    int DP(string bits, int pos, int count, int tight)
    {
        if (pos == bits.Length) return isPrime[count] ? 1 : 0;
        if (dp[pos, count, tight] != -1) return dp[pos, count, tight];
        int limit = (tight == 1) ? bits[pos] - '0' : 1;
        int ans = 0;
        for (int bit = 0; bit <= limit; bit++)
        {
            int newTight = ((tight == 1) & (bit == limit)) ? 1 : 0;
            ans += DP(bits, pos + 1, count + bit, newTight);
        }
        dp[pos, count, tight] = ans;
        return dp[pos, count, tight];
    }
}