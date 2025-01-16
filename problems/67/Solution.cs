#if DEBUG
namespace Problems_67;
#endif

public class Solution
{
    public string AddBinary(string a, string b)
    {
        StringBuilder sb = new();
        int carry = 0, i = a.Length - 1, j = b.Length - 1;
        while (i >= 0 || j >= 0 || carry > 0)
        {
            int digitA = i >= 0 ? a[i--] - '0' : 0;
            int digitB = j >= 0 ? b[j--] - '0' : 0;
            int sum = digitA + digitB + carry;
            sb.Insert(0, sum % 2);
            carry = sum / 2;
        }

        return sb.ToString();
    }
}