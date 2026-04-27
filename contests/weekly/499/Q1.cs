public class Solution
{
    public IList<int> FindValidElements(int[] nums)
    {
        List<int> ans = [];
        int n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            bool isValid = true;
            for (int j = 0; j < i; j++)
            {
                if (nums[i] <= nums[j])
                {
                    isValid = false;
                    break;
                }
            }
            if (isValid)
            {
                ans.Add(nums[i]);
                continue;
            }

            isValid = true;

            for (int j = n - 1; j > i; j--)
            {
                if (nums[i] <= nums[j])
                {
                    isValid = false;
                    break;
                }
            }
            if (isValid)
            {
                ans.Add(nums[i]);
                continue;
            }
        }
        return ans;
    }
}
