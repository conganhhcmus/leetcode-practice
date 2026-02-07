public class Solution
{
    public int[] PivotArray(int[] nums, int pivot)
    {
        int n = nums.Length;
        int lessIdx = 0, greaterIdx = n - 1;
        int[] ans = new int[n];
        for (int i = 0; i < n; i++)
        {
            if (nums[i] < pivot) ans[lessIdx++] = nums[i];
            if (nums[n - i - 1] > pivot) ans[greaterIdx--] = nums[n - i - 1];
        }
        while (lessIdx <= greaterIdx) ans[lessIdx++] = pivot;
        return ans;
    }
}