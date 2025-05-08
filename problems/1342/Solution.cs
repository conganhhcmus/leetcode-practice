#if DEBUG
namespace Problems_1342;
#endif

public class Solution
{
    public int NumberOfSteps(int num)
    {
        int count = 0;
        while (num > 0)
        {
            if (num % 2 == 1)
            {
                num--;
            }
            else
            {
                num >>= 1;
            }
            count++;
        }

        return count;
    }
}