namespace Problem_162;

public class Solution
{
    public int FindPeakElement(int[] nums)
    {
        int n = nums.Length;
        int s = 0;
        int e = n - 1;

        while (s < e)
        {
            int mid = s + (e - s) / 2;

            if ((mid == 0 || nums[mid] > nums[mid - 1]) &&
                (mid == n - 1 || nums[mid] > nums[mid + 1]))
            {
                return mid;
            }

            if (nums[mid + 1] > nums[mid])
            {
                s = mid + 1;
            }
            else
            {
                e = mid - 1;
            }
        }

        return s;
    }
}