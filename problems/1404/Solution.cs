public class Solution
{
    public int NumSteps(string s)
    {
        int ans = 0;
        while (!IsOne(s))
        {
            if (s[^1] == '0')
            {
                s = Divide(s);
            }
            else
            {
                s = Add(s);
            }
            ans++;
        }

        return ans;
    }

    bool IsOne(string s)
    {
        if (s.Length > 1) return false;
        return s[0] == '1';
    }

    string Add(string s)
    {
        string ans = "";
        int n = s.Length;
        int sign = 1;
        for (int i = n - 1; i >= 0; i--)
        {
            int digit = (s[i] - '0') + sign;
            sign = digit / 2;
            digit %= 2;
            ans = digit.ToString() + ans;
        }

        while (sign > 0)
        {
            int digit = sign % 2;
            sign /= 2;
            ans = digit.ToString() + ans;
        }

        return ans;
    }

    string Divide(string s)
    {
        int n = s.Length;
        return s[..(n - 1)];
    }
}