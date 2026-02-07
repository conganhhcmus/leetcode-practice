public class Solution
{
    public int FindIntegers(int n)
    {
        List<int> digits = ToBinary(n);
        return DP(digits.Count - 1, 1, 0, digits);
    }

    Dictionary<(int, int, int), int> memo = [];

    int DP(int pos, int tight, int last, List<int> digits)
    {
        if (pos < 0) return 1;
        var key = (pos, tight, last);
        if (memo.TryGetValue(key, out int cached)) return cached;
        int ret = 0;
        int max = tight == 1 ? digits[pos] : 1;
        for (int d = 0; d <= max; d++)
        {
            if (last == 1 && d == 1) continue;
            int newTight = d == digits[pos] ? tight : 0;
            ret += DP(pos - 1, newTight, d, digits);
        }
        memo[key] = ret;
        return ret;
    }

    List<int> ToBinary(int n)
    {
        List<int> ret = [];
        while (n > 0)
        {
            ret.Add(n & 1);
            n >>= 1;
        }

        return ret;
    }
}