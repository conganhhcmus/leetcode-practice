#if DEBUG
namespace Problems_2335_3;
#endif

public class Solution
{
    public int FillCups(int[] amount)
    {
        int max = 0;
        int total = 0;
        foreach (int val in amount)
        {
            if (val > max)
            {
                max = val;
            }
            total += val;
        }

        return Math.Max(max, (total + 1) / 2);
    }
}