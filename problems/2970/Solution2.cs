public class Solution
{
    public int IncremovableSubarrayCount(int[] nums)
    {
        int n = nums.Length;
        int left = 0, right = n - 1;
        while (left + 1 < n && nums[left] < nums[left + 1]) left++;
        while (right - 1 >= 0 && nums[right] > nums[right - 1]) right--;
        if (left == n - 1) return n * (n + 1) / 2;

        int ret = (left + 1) + (n - right);
        for (int i = 0, j = right; j < n; j++)
        {
            while (i <= left && nums[i] < nums[j]) i++;
            ret += i;
        }
        return ret + 1;
    }
}