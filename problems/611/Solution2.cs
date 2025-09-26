#if DEBUG
namespace Problems_611_2;
#endif

public class Solution
{
    public int TriangleNumber(int[] nums)
    {
        Array.Sort(nums);
        int n = nums.Length;
        int count = 0;
        for (int k = n - 1; k > 1; k--)
        {
            int l = 0, r = k - 1;
            while (l < r)
            {
                if (nums[k] < nums[l] + nums[r])
                {
                    count += r - l;
                    r--;
                }
                else
                {
                    l++;
                }
            }
        }
        return count;
    }
}