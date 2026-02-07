public class Solution
{
    public int FirstMissingPositive(int[] nums)
    {
        int n = nums.Length;
        // replace all element <=0 || > n
        for (int i = 0; i < n; i++)
        {
            if (nums[i] <= 0 || nums[i] > n)
            {
                nums[i] = n + 1;
            }
        }

        // mark each element by index, use given array, so don't count space
        for (int i = 0; i < n; i++)
        {
            int num = Math.Abs(nums[i]);
            if (num > n) continue;
            if (nums[num - 1] > 0)
            {
                nums[num - 1] *= -1;
            }
        }

        // find first positive index, it is first missing positive number
        for (int i = 0; i < n; i++)
        {
            if (nums[i] > 0) return i + 1;
        }

        // if not exist, it is n-1
        return n + 1;
    }
}