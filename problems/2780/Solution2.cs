#if DEBUG
namespace Problems_2780_2;
#endif

public class Solution
{
    public int MinimumIndex(IList<int> nums)
    {
        int n = nums.Count;
        int dominant = nums[0];
        int count = 0;
        foreach (int num in nums)
        {
            if (count == 0)
            {
                dominant = num;
                count = 1;
            }
            else if (dominant == num)
            {
                count++;
            }
            else
            {
                count--;
            }
        }

        int rightCount = 0;
        foreach (int num in nums)
        {
            if (num == dominant)
            {
                rightCount++;
            }
        }

        int leftCount = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] == dominant)
            {
                leftCount++;
                rightCount--;
            }

            if (2 * leftCount > i + 1 && 2 * rightCount > n - i - 1)
            {
                return i;
            }
        }
        return -1;
    }
}