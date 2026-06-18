public class Solution
{
    public int CountElements(int[] nums, int k)
    {
        int n = nums.Length;
        Array.Sort(nums);
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            int x = nums[i];
            int low = i, high = n - 1, best = n;
            while (low <= high)
            {
                int mid = (low + high) >> 1;
                if (nums[mid] == x)
                {
                    best = mid;
                    low = mid + 1;
                }
                else if (nums[mid] > x)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            if (best + k < n) ans++;
        }
        return ans;
    }
}
