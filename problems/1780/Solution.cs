#if DEBUG
namespace Problems_1780;
#endif

public class Solution
{
    public bool CheckPowersOfThree(int n)
    {
        while (n > 0)
        {
            if (n % 3 == 2)
            {
                return false;
            }
            n /= 3;
        }
        return true;
    }
}