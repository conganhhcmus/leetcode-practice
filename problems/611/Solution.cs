public class Solution
{
    public int TriangleNumber(int[] nums)
    {
        Array.Sort(nums);
        int n = nums.Length;
        int count = 0;
        for (int i = 0; i < n - 2; i++)
        {
            if (nums[i] == 0) continue;
            for (int j = i + 1, k = i + 2; j < n; j++)
            {
                while (k < n && nums[i] + nums[j] > nums[k]) k++;
                count += k - j - 1;
            }
        }
        return count;
    }
}