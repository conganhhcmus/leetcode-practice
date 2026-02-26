public class Solution
{
    public int NumSteps(string s)
    {
        int n = s.Length;
        int sign = 0;
        int ans = 0;
        for (int i = n - 1; i > 0; i--)
        {
            int digit = (s[i] - '0') + sign;
            sign = digit / 2;
            digit %= 2;
            if (digit == 0) ans++;
            else
            {
                sign++;
                ans += 2;
            }
        }
        if (sign > 0) ans++;
        return ans;
    }
}