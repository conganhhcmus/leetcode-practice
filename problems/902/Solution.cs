#if DEBUG
namespace Problems_902;
#endif

public class Solution
{
    public int AtMostNGivenDigitSet(string[] digits, int n)
    {
        List<int> nDigits = [];
        List<int> gDigits = [];
        foreach (string digit in digits)
        {
            gDigits.Add(int.Parse(digit));
        }
        while (n > 0)
        {
            nDigits.Add(n % 10);
            n /= 10;
        }
        return DP(nDigits.Count - 1, 1, 1, nDigits, gDigits);
    }

    Dictionary<(int, int, int), int> memo = [];

    int DP(int pos, int tight, int leadingZero, List<int> nDigits, List<int> gDigits)
    {
        if (pos < 0) return leadingZero == 1 ? 0 : 1;
        int max = tight == 1 ? nDigits[pos] : 9;
        var key = (pos, tight, leadingZero);
        if (memo.TryGetValue(key, out int cached)) return cached;
        int ret = 0;
        if (leadingZero == 1) ret += DP(pos - 1, 0, 1, nDigits, gDigits);
        foreach (int d in gDigits)
        {
            if (d > max) break;
            int newTight = d == nDigits[pos] ? tight : 0;
            int newLeadingZero = d == 0 ? leadingZero : 0;
            ret += DP(pos - 1, newTight, newLeadingZero, nDigits, gDigits);
        }

        memo[key] = ret;
        return ret;
    }
}