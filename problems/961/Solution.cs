#if DEBUG
namespace Problems_961;
#endif

public class Solution
{
    public int RepeatedNTimes(int[] nums)
    {
        HashSet<int> set = [];
        foreach (int num in nums)
        {
            if (!set.Add(num)) return num;
        }
        return -1;
    }
}