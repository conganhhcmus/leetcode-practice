#if DEBUG
namespace Problems_287;
#endif

public class Solution
{
    public int FindDuplicate(int[] nums)
    {
        int slow = nums[0];
        int fast = nums[0];
        do
        {
            slow = nums[slow]; // 1 step
            fast = nums[nums[fast]]; // 2 steps
        } while (slow != fast);

        int p1 = nums[0];
        int p2 = slow;
        while (p1 != p2)
        {
            p1 = nums[p1];
            p2 = nums[p2];
        }

        return p1;
    }
}