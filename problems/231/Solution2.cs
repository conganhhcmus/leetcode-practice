#if DEBUG
namespace Problems_231_2;
#endif

public class Solution
{
    public bool IsPowerOfTwo(int n)
    {
        if (n <= 0) return false;
        return (n & (n - 1)) == 0;
    }
}