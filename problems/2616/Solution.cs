public class Solution
{
    public int MinimizeMax(int[] nums, int p)
    {
        if (p == 0) return 0;
        Array.Sort(nums);
        int max = nums[^1], min = nums[0];

        int low = 0, high = max - min, ans = high;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (Ok(nums, mid, p))
            {
                ans = mid;
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return ans;
    }

    bool Ok(int[] nums, int mid, int p)
    {
        int n = nums.Length;
        for (int i = 1; i < n && p > 0; i++)
        {
            if (nums[i] - nums[i - 1] <= mid)
            {
                p--;
                i++;
            }
        }
        return p == 0;
    }
}