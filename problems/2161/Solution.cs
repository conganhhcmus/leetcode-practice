public class Solution
{
    public int[] PivotArray(int[] nums, int pivot)
    {
        int n = nums.Length;
        int[] ans = new int[n];
        int p = 0, countEquals = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] < pivot)
            {
                ans[p++] = nums[i];
            }
            else if (nums[i] == pivot)
            {
                countEquals++;
            }
        }
        for (int i = 0; i < countEquals; i++) ans[p++] = pivot;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] > pivot)
            {
                ans[p++] = nums[i];
            }
        }
        return ans;
    }
}