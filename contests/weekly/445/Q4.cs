#if DEBUG
namespace Weekly_445_Q4;
#endif

public class Solution
{
    int mod = (int)1e9 + 7;
    public int CountNumbers(string l, string r, int b)
    {
        List<int> lDigits = ToBase(l, b);
        List<int> rDigits = ToBase(r, b);
        int extra = 0;
        if (IsNonDecrease(lDigits)) extra = 1;

        long[,,] memoR = new long[rDigits.Count, 2, 10];
        for (int i = 0; i < rDigits.Count; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                for (int k = 0; k < 10; k++)
                {
                    memoR[i, j, k] = -1;
                }
            }
        }

        long[,,] memoL = new long[rDigits.Count, 2, 10];
        for (int i = 0; i < rDigits.Count; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                for (int k = 0; k < 10; k++)
                {
                    memoL[i, j, k] = -1;
                }
            }
        }
        long right = DP(0, 1, 0, b, rDigits, memoR);
        long left = DP(0, 1, 0, b, lDigits, memoL);

        long ret = (right - left + extra) % mod;
        ret = (ret + mod) % mod;
        return (int)ret;
    }

    long DP(int pos, int tight, int last, int b, List<int> digits, long[,,] memo)
    {
        if (pos >= digits.Count) return 1;
        if (memo[pos, tight, last] != -1) return memo[pos, tight, last];

        long ret = 0;
        int max = (tight != 0) ? digits[pos] : b - 1;
        int min = last;

        for (int d = min; d <= max; d++)
        {
            int newTight = (d == digits[pos]) ? tight : 0;
            ret = (ret + DP(pos + 1, newTight, d, b, digits, memo)) % mod;
        }

        memo[pos, tight, last] = ret;
        return ret;
    }

    List<int> ToBase(string num, int b)
    {
        List<int> digits = [];
        while (num != "0")
        {
            (string next, int rem) = Divide(num, b);
            digits.Add(rem);
            num = next;
        }
        digits.Reverse();
        return digits;
    }

    (string quotient, int remainder) Divide(string num, int b)
    {
        StringBuilder sb = new();
        int sign = 0;
        foreach (char c in num)
        {
            int d = c - '0';
            int val = sign * 10 + d;
            sb.Append(val / b);
            sign = val % b;
        }
        string ret = sb.ToString().TrimStart('0');
        if (string.IsNullOrEmpty(ret)) ret = "0";
        return (ret, sign);
    }

    bool IsNonDecrease(List<int> nums)
    {
        for (int i = 1; i < nums.Count; i++)
        {
            if (nums[i] < nums[i - 1]) return false;
        }
        return true;
    }
}