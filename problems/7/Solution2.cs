#if DEBUG
namespace Problems_7_2;
#endif

public class Solution
{
    public int Reverse(int x)
    {
        int ans = 0;
        while (x != 0)
        {
            int digit = x % 10;
            if (ans > int.MaxValue / 10) return 0;
            if (ans < int.MinValue / 10) return 0;
            ans = ans * 10 + digit;
            x /= 10;
        }
        return ans;
    }
}