public class Solution
{
    public int MissingNumber(int[] nums)
    {
        int n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            while (nums[i] < n && nums[i] != nums[nums[i]])
            {
                (nums[i], nums[nums[i]]) = (nums[nums[i]], nums[i]);
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (nums[i] != i) return i;
        }

        return n;
    }
}
