public class Solution
{
    public int MissingInteger(int[] nums)
    {
        int n = nums.Length;
        int sum = nums[0];
        int i = 1;
        while (i < n && nums[i] == nums[i - 1] + 1)
        {
            sum += nums[i];
            i++;
        }
        i--;
        long mark = 0;
        while (i < n)
        {
            if (nums[i] >= sum)
            {
                mark |= 1L << (nums[i] - sum);
            }
            i++;
        }
        while ((mark & 1) == 1)
        {
            sum++;
            mark >>= 1;
        }
        return sum;
    }
}
