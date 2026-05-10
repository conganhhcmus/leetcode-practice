public class Solution
{
    public int MissingNumber(int[] nums)
    {
        int n = nums.Length;
        int MAX = n + 1;

        for (int i = 0; i < n; i++)
        {
            int x = nums[i];

            if (x < 0)
            {
                x += MAX;
            }

            if (x < n)
            {
                nums[x] -= MAX;
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (nums[i] >= 0)
            {
                return i;
            }
        }

        return n;
    }
}
