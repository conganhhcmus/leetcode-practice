#if DEBUG
namespace Problems_66;
#endif

public class Solution
{
    public int[] PlusOne(int[] digits)
    {
        int n = digits.Length;
        int carry = 1;
        for (int i = n - 1; i >= 0; i--)
        {
            digits[i] += carry;
            carry = digits[i] / 10;
            digits[i] %= 10;
        }
        if (carry > 0)
        {
            int[] ret = new int[n + 1];
            ret[0] = carry;
            Array.Copy(digits, 0, ret, 1, n);
            return ret;
        }
        return digits;
    }
}