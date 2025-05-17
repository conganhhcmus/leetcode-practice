#if DEBUG
namespace Problems_233_2;
#endif

public class Solution
{
    public int CountDigitOne(int n)
    {
        int ret = 0;
        for (int i = 1; i <= n; i *= 10)
        {
            int a = n / i;
            int b = n % i;
            int x = a % 10;
            if (x == 1) ret += (a / 10) * i + (b + 1);
            else if (x == 0) ret += (a / 10) * i;
            else ret += (a / 10 + 1) * i;
        }
        return ret;
    }
}