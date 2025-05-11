#if DEBUG
namespace Problems_2357_2;
#endif

public class Solution
{
    public int MinimumOperations(int[] nums)
    {
        bool[] map = new bool[101];
        foreach (int num in nums)
        {
            map[num] = true;
        }
        int ret = 0;
        for (int i = 1; i < 101; i++)
        {
            if (map[i]) ret++;
        }
        return ret;
    }
}