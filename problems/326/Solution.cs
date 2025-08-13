#if DEBUG
namespace Problems_326;
#endif

public class Solution
{
    public bool IsPowerOfThree(int n)
    {
        if (n <= 0) return false;
        while (n >= 3)
        {
            if (n % 3 != 0) return false;
            n /= 3;
        }
        return n == 1;
    }
}