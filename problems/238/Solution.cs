public class Solution
{
    public int[] ProductExceptSelf(int[] nums)
    {
        int[] result = new int[nums.Length];
        int[] dp1 = new int[nums.Length + 1];
        int[] dp2 = new int[nums.Length + 1];
        dp1[0] = 1;
        dp2[0] = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            dp1[i + 1] = dp1[i] * nums[i];
            dp2[i + 1] = dp2[i] * nums[^(i + 1)];
        }

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = dp1[i] * dp2[^(i + 2)];
        }

        return result;
    }

    private int[] ProductExceptSelf_Enhance(int[] nums)
    {
        int[] output = new int[nums.Length];
        output[0] = 1;
        int right = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            output[i] = output[i - 1] * nums[i - 1];
        }

        for (int j = nums.Length - 1; j >= 0; j--)
        {
            output[j] = output[j] * right;
            right *= nums[j];
        }

        return output;
    }
}