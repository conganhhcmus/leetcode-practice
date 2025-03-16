#if DEBUG
namespace Weekly_441_Q4;
#endif

public class Solution
{
    public int BeautifulNumbers(int l, int r)
    {
        List<int> digits1 = GetDigits(r);
        List<int> digits2 = GetDigits(l - 1);

        int count1 = CountBeautifulNumbers(digits1);
        int count2 = CountBeautifulNumbers(digits2);
        return count1 - count2;
    }

    private int CountBeautifulNumbers(List<int> digits)
    {
        Dictionary<string, int> memo = [];
        return DP(digits.Count - 1, true, 0, 1, true, digits, memo);
    }

    private List<int> GetDigits(int n)
    {
        List<int> res = [];
        if (n == 0)
        {
            res.Add(0);
            return res;
        }
        while (n > 0)
        {
            res.Add(n % 10);
            n /= 10;
        }
        return res;
    }

    private int DP(int idx, bool tight, int sumSoFar, int productSoFar, bool leadingZero, List<int> digits, Dictionary<string, int> memo)
    {
        if (idx < 0)
        {
            return (sumSoFar > 0 && productSoFar % sumSoFar == 0) ? 1 : 0;
        }

        var key = $"{idx}_{tight}_{sumSoFar}_{productSoFar}";
        if (memo.TryGetValue(key, out int cached))
        {
            return cached;
        }

        int limit = tight ? digits[idx] : 9;
        int count = 0;

        for (int d = 0; d <= limit; d++)
        {
            bool newTight = tight && (d == limit);
            bool newLeadingZero = leadingZero && (d == 0);
            int newSum = sumSoFar;
            int newProduct = productSoFar;

            if (leadingZero)
            {
                if (d != 0)
                {
                    newSum = d;
                    newProduct = d;
                    newLeadingZero = false;
                }
            }
            else
            {
                newSum += d;
                newProduct *= d;
            }

            count += DP(idx - 1, newTight, newSum, newProduct, newLeadingZero, digits, memo);
        }

        memo[key] = count;
        return count;
    }
}