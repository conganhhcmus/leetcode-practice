public class Solution
{
    public int MaxProduct(int[] nums)
    {
        int ret = nums[0], maxProduct = nums[0], minProduct = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] < 0)
            {
                (maxProduct, minProduct) = (minProduct, maxProduct);
            }

            minProduct = Math.Min(nums[i], minProduct * nums[i]);
            maxProduct = Math.Max(nums[i], maxProduct * nums[i]);
            ret = Math.Max(ret, maxProduct);
        }
        return ret;
    }
}