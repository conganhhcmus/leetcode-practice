#if DEBUG
namespace Problems_75;
#endif

public class Solution
{
    public void SortColors(int[] nums)
    {
        int n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (nums[i] > nums[j])
                {
                    (nums[i], nums[j]) = (nums[j], nums[i]);
                }
            }
        }
    }
}