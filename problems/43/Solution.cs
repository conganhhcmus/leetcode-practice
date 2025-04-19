#if DEBUG
namespace Problems_43;
#endif

public class Solution
{
    public string Multiply(string num1, string num2)
    {
        string ret = "0";
        if (IsZero(num1) || IsZero(num2)) return ret;
        int n1 = num1.Length;
        int n2 = num2.Length;
        string based = "";
        for (int i = n1 - 1; i >= 0; --i)
        {
            StringBuilder sb = new(based);
            int sign = 0;

            for (int j = n2 - 1; j >= 0; --j)
            {
                int digit1 = num1[i] - '0';
                int digit2 = num2[j] - '0';
                int digit = (digit1 * digit2 + sign) % 10;
                sign = (digit1 * digit2 + sign) / 10;
                sb.Append(digit);
            }
            if (sign > 0) sb.Append(sign);
            ret = Add(ret, sb.ToString());
            based += '0';
        }
        return Reverse(ret);
    }

    bool IsZero(string s)
    {
        foreach (char c in s)
        {
            if (c != '0') return false;
        }
        return true;
    }
    string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    string Add(string num1, string num2)
    {
        if (num1.Length < num2.Length) return Add(num2, num1);
        int n = num1.Length;
        num2 = num2.PadRight(n, '0');
        StringBuilder sb = new();
        int sign = 0;
        for (int i = 0; i < n; i++)
        {
            int digit1 = num1[i] - '0';
            int digit2 = num2[i] - '0';
            int digit = (digit1 + digit2 + sign) % 10;
            sign = (digit1 + digit2 + sign) / 10;
            sb.Append(digit);
        }
        if (sign > 0)
        {
            sb.Append(sign);
        }
        return sb.ToString();
    }
}