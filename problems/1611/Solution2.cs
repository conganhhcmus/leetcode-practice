#if DEBUG
namespace Problems_1611_2;
#endif

public class Solution
{
    public int MinimumOneBitOperations(int n)
    {
        if (n == 0) return 0;
        // find the left most set bit
        int k = CountBits(n) - 1;

        return (1 << (k + 1)) - 1 - MinimumOneBitOperations(n ^ (1 << k));
    }

    int CountBits(int n)
    {
        int ans = 0;
        while (n > 0)
        {
            ans++;
            n >>= 1;
        }
        return ans;
    }
}