#if DEBUG
namespace Problems_1295;
#endif

public class Solution
{
    public int FindNumbers(int[] nums)
    {
        int count = 0;
        foreach (int num in nums)
        {
            int digits = 0;
            int n = num;
            while (n > 0)
            {
                digits++;
                n /= 10;
            }
            if (digits % 2 == 0) count++;
        }
        return count;
    }
}