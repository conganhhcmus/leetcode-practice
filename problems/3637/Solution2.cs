public class Solution
{
    public bool IsTrionic(int[] nums)
    {
        int n = nums.Length;
        int i = 1;
        while (i < n && nums[i] > nums[i - 1]) i++;
        int p = i - 1;
        while (i < n && nums[i] < nums[i - 1]) i++;
        int q = i - 1;
        while (i < n && nums[i] > nums[i - 1]) i++;
        int flag = i - 1;
        return p != 0 && q != p && flag == n - 1 && flag != q;
    }
}