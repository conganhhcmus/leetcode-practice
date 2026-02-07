public class Solution
{
    public int NumDupDigitsAtMostN(int n)
    {
        List<int> digits = [];
        while (n > 0)
        {
            digits.Add(n % 10);
            n /= 10;
        }
        int[] count = new int[10];
        return DP(digits.Count - 1, 1, 1, 0, 0, digits);
    }

    Dictionary<(int, int, int, int, int), int> memo = [];

    int DP(int pos, int tight, int leadingZero, int repeat, int bitMask, List<int> digits)
    {
        if (pos < 0) return repeat == 1 ? 1 : 0;
        var key = (pos, tight, leadingZero, repeat, bitMask);
        if (memo.TryGetValue(key, out int cache)) return cache;
        int ret = 0;
        if (leadingZero == 1) ret += DP(pos - 1, 0, 1, repeat, bitMask, digits);
        int min = leadingZero == 1 ? 1 : 0;
        int max = tight == 1 ? digits[pos] : 9;
        for (int d = min; d <= max; d++)
        {
            int newTight = d == digits[pos] ? tight : 0;
            int newRepeat = (bitMask & (1 << d)) != 0 ? 1 : repeat;
            ret += DP(pos - 1, newTight, 0, newRepeat, bitMask | (1 << d), digits);
        }

        memo[key] = ret;
        return ret;
    }
}