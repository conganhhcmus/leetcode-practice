namespace Problem_8;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        Console.WriteLine(solution.MyAtoi("42")); // Output: 42
        Console.WriteLine(solution.MyAtoi("   -42")); // Output: -42
        Console.WriteLine(solution.MyAtoi("4193 with words")); // Output: 4193
        Console.WriteLine(solution.MyAtoi("words and 987")); // Output: 0
        Console.WriteLine(solution.MyAtoi("-91283472332")); // Output: -2147483648
        Console.WriteLine(solution.MyAtoi("0-1")); // Output: 0
    }

    public int MyAtoi(string s)
    {
        var res = 0;
        int sign = 1;
        int pos = 0;
        s = s.Trim();
        if (s.Length == 0) return 0;
        if (s[0] == '-')
        {
            sign = -1;
            pos = 1;
        }

        if (s[0] == '+')
        {
            sign = 1;
            pos = 1;
        }

        for (int i = pos; i < s.Length; i++)
        {
            if (s[i] >= '0' && s[i] <= '9')
            {
                int digit = s[i] - '0';
                if (sign > 0)
                {
                    if (res > (int.MaxValue - digit) / 10) return int.MaxValue;
                }
                else
                {
                    if (res * sign < (int.MinValue + digit) / 10) return int.MinValue;
                }

                res = res * 10 + digit;
            }
            else
            {
                break;
            }
        }

        return res * sign;
    }
}