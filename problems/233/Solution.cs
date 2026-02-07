public class Solution
{
    public int CountDigitOne(int n)
    {
        List<int> digits = [];
        while (n > 0)
        {
            digits.Add(n % 10);
            n /= 10;
        }
        int len = digits.Count;
        int[,,] memo = new int[len, 2, len];
        for (int i = 0; i < len; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                for (int k = 0; k < len; k++)
                {
                    memo[i, j, k] = -1;
                }
            }
        }
        return DP(len - 1, 1, 0, digits, memo);
    }

    int DP(int pos, int tight, int count, List<int> digits, int[,,] memo)
    {
        if (pos < 0) return count;
        if (memo[pos, tight, count] != -1) return memo[pos, tight, count];
        int ret = 0;
        int max = (tight == 1) ? digits[pos] : 9;
        for (int d = 0; d <= max; d++)
        {
            int newTight = (d == digits[pos]) ? tight : 0;
            int extra = (d == 1) ? 1 : 0;
            ret += DP(pos - 1, newTight, count + extra, digits, memo);
        }

        memo[pos, tight, count] = ret;
        return ret;
    }
}