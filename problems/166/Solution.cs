#if DEBUG
namespace Problems_166;
#endif

public class Solution
{
    public string FractionToDecimal(int numerator, int denominator)
    {
        Dictionary<long, int> calc = [];
        StringBuilder ans = new();
        StringBuilder decimalDigit = new();
        long num = numerator;
        long den = denominator;
        if (num * den < 0) ans.Append('-');
        num = Math.Abs(num);
        den = Math.Abs(den);
        ans.Append(num / den);
        num %= den;
        if (num == 0) return ans.ToString();
        ans.Append('.');
        int pos = 0;
        while (num > 0)
        {
            if (calc.ContainsKey(num)) break;
            calc[num] = pos++;
            num *= 10;
            decimalDigit.Append(num / den);
            num %= den;
        }

        if (num != 0)
        {
            decimalDigit.Insert(calc[num], '(');
            decimalDigit.Append(')');
        }
        ans.Append(decimalDigit);

        return ans.ToString();
    }
}