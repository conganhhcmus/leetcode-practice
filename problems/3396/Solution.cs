#if DEBUG
namespace Problems_3396;
#endif

public class Solution
{
    public int MinimumOperations(int[] nums)
    {
        int n = nums.Length;
        bool[] seen = new bool[101];

        for (int i = n - 1; i >= 0; i--)
        {
            if (seen[nums[i]])
            {
                return (i / 3) + 1;
            }
            seen[nums[i]] = true;
        }

        return 0;
    }
}