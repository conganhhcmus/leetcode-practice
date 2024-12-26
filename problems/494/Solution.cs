#if DEBUG
namespace Problems_494;
#endif

public class Solution
{
    public int FindTargetSumWays(int[] nums, int target)
    {
        int[] expressions = [-1, 1];
        int result = 0;
        void BackTracking(int target, int curr)
        {
            if (curr == nums.Length)
            {
                if (target == 0) result++;
                return;
            }

            foreach (int exp in expressions)
            {
                BackTracking(target + exp * nums[curr], curr + 1);
            }
        }

        BackTracking(target, 0);
        return result;
    }
}