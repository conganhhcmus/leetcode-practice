#if DEBUG
namespace Problems_342_2;
#endif

public class Solution
{
    public bool IsPowerOfFour(int n)
    {
        if (n <= 0) return false;
        // check only 1 set bits
        if ((n & (n - 1)) != 0) return false;
        // check set bits at even position
        // bitMask = 101010...1010
        int bitMask = 715827882;
        return (bitMask & n) == 0;
    }
}