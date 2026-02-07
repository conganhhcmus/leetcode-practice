public class Solution
{
    public int FindUnsortedSubarray(int[] nums)
    {
        int n = nums.Length;
        int[] prefixMin = new int[n];
        int[] suffixMax = new int[n];
        prefixMin[^1] = nums[^1];
        for (int i = n - 2; i >= 0; i--)
        {
            prefixMin[i] = Math.Min(prefixMin[i + 1], nums[i]);
        }
        suffixMax[0] = nums[0];
        for (int i = 1; i < n; i++)
        {
            suffixMax[i] = Math.Max(suffixMax[i - 1], nums[i]);
        }
        int left = 0, right = n - 1;
        while (left < n && nums[left] <= prefixMin[left]) left++;
        while (right >= 0 && nums[right] >= suffixMax[right]) right--;
        if (left >= right) return 0;
        return right - left + 1;
    }
}