#if DEBUG
namespace Problems_1295_4;
#endif

public class Solution
{
    public int FindNumbers(int[] nums)
    {
        int count = 0;
        foreach (int num in nums)
        {
            if ((num >= 10 && num <= 99) || (num >= 1000 && num <= 9999) || num == 100000) count++;
        }
        return count;
    }
}