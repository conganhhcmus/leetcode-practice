#if DEBUG
using System.Numerics;

namespace Weekly_445_Q4;
#endif

public class Solution
{
    int mod = (int)1e9 + 7;
    public int CountNumbers(string l, string r, int b)
    {
        string low = ConvertToBase(l, b);
        string high = ConvertToBase(r, b);
        int n = high.Length;
        low = low.PadLeft(n, '0');
        long[] memo = new long[n];
        Array.Fill(memo, -1);
        long ret = DP(0, true, true, low, high, memo);
        return (int)(ret % mod);
    }

    long DP(int i, bool limitLow, bool limitHigh, string low, string high, long[] memo)
    {
        if (i == low.Length) return 1;
        if (!limitLow && !limitHigh && memo[i] != -1) return memo[i];
        int lo = limitLow ? low[i] - '0' : 0;
        int hi = limitHigh ? high[i] - '0' : 9;
        long res = 0;
        for (int digit = lo; digit <= hi; digit++)
        {
            res += DP(i + 1, limitLow && digit == lo, limitHigh && digit == hi, low, high, memo);
        }
        if (!limitLow && !limitHigh) memo[i] = res;
        return res;
    }

    string ConvertToBase(string num, int b)
    {
        string ret = "";
        BigInteger bigInt = BigInteger.Parse(num);
        while (bigInt > 0)
        {
            ret += bigInt % b;
            bigInt /= b;
        }

        return ret;
    }
}