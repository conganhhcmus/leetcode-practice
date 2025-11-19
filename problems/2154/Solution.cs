#if DEBUG
namespace Problems_2154;
#endif

public class Solution
{
    public int FindFinalValue(int[] nums, int original)
    {
        bool[] seem = new bool[10000];
        foreach (int num in nums)
        {
            seem[num] = true;
        }
        while (seem[original])
        {
            original *= 2;
        }
        return original;
    }
}