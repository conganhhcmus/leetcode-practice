#if DEBUG
namespace Problems_231;
#endif

public class Solution
{
    public bool IsPowerOfTwo(int n)
    {
        int count = 0;
        while (n > 0)
        {
            count += n & 1;
            n >>= 1;
        }

        return count == 1;
    }
}