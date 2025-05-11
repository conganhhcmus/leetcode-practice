#if DEBUG
namespace Problems_1550;
#endif

public class Solution
{
    public bool ThreeConsecutiveOdds(int[] arr)
    {
        int count = 0;
        foreach (int num in arr)
        {
            if (num % 2 == 0)
            {
                count = 0;
            }
            else
            {
                count++;
                if (count == 3) return true;
            }
        }
        return false;
    }
}