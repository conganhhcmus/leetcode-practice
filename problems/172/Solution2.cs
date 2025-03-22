#if DEBUG
namespace Problems_172_2;
#endif

public class Solution
{
    public int TrailingZeroes(int n)
    {
        int ans = 0;
        while (n > 0)
        {
            ans += n / 5;
            n /= 5;
        }
        return ans;
    }
}