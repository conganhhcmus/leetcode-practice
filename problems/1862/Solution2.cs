public class Solution
{
    public int SumOfFlooredPairs(int[] nums)
    {
        Array.Sort(nums);
        int mod = 1000000007, n = nums.Length;
        long ans = 0;
        for (int i = 0; i < n;)
        {
            int j = i + 1;
            while (j < n && nums[j] == nums[j - 1]) ++j; // skip the duplicates of `nums[i]`
            int dup = j - i;
            ans = (ans + 1L * dup * dup % mod) % mod; // the `dup` duplicates add `dup * dup` to the answer
            while (j < n)
            {
                int div = nums[j] / nums[i], bound = nums[i] * (div + 1);
                int next = BinarySearch(nums, bound);
                ans = (ans + 1L * (next - j) * div * dup) % mod; // Each nums[t] (j <= t < next) will add `div * dup` to the answer.
                j = next;
            }
            i += dup;
        }
        return (int)ans;
    }

    private int BinarySearch(int[] nums, int k)
    {
        int left = 0, right = nums.Length - 1;
        int ans = nums.Length;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (nums[mid] >= k)
            {
                ans = mid;
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }

        }
        return ans;
    }
}