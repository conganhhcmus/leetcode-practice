public class Solution
{
    public int[] MaxValue(int[] nums)
    {
        int n = nums.Length;

        int[] prefixMax = new int[n];
        int[] suffixMin = new int[n];

        prefixMax[0] = nums[0];
        for (int i = 1; i < n; i++)
        {
            prefixMax[i] = Math.Max(prefixMax[i - 1], nums[i]);
        }

        suffixMin[n - 1] = nums[n - 1];
        for (int i = n - 2; i >= 0; i--)
        {
            suffixMin[i] = Math.Min(suffixMin[i + 1], nums[i]);
        }

        int[] ans = new int[n];

        int start = 0;
        int compMax = nums[0];

        for (int i = 0; i < n - 1; i++)
        {
            compMax = Math.Max(compMax, nums[i]);

            // split component
            if (prefixMax[i] <= suffixMin[i + 1])
            {
                for (int j = start; j <= i; j++)
                {
                    ans[j] = compMax;
                }

                start = i + 1;

                if (start < n) compMax = nums[start];
            }
        }

        // last component
        compMax = Math.Max(compMax, nums[n - 1]);

        for (int j = start; j < n; j++)
        {
            ans[j] = compMax;
        }

        return ans;
    }
}
