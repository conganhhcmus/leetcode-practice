#if DEBUG
namespace Problems_3201_2;
#endif

public class Solution
{
    public int MaximumLength(int[] nums)
    {
        int ret = 0;
        int[][] patterns = [[0, 0], [0, 1], [1, 0], [1, 1]];
        foreach (int[] pattern in patterns)
        {
            int count = 0;
            foreach (int num in nums)
            {
                if (num % 2 == pattern[count % 2])
                {
                    count++;
                }
            }
            ret = Math.Max(ret, count);
        }
        return ret;
    }
}