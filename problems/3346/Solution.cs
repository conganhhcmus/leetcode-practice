#if DEBUG
namespace Problems_3346;
#endif

public class Solution
{
    public int MaxFrequency(int[] nums, int k, int numOperations)
    {
        int n = nums.Length;
        Array.Sort(nums);
        int ans = 0;
        Dictionary<int, int> numCount = [];
        int lastNumIndex = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] != nums[lastNumIndex])
            {
                numCount[nums[lastNumIndex]] = i - lastNumIndex;
                ans = Math.Max(ans, i - lastNumIndex);
                lastNumIndex = i;
            }
        }

        numCount[nums[lastNumIndex]] = n - lastNumIndex;
        ans = Math.Max(ans, n - lastNumIndex);

        for (int i = nums[0]; i <= nums[^1]; i++)
        {
            int l = LeftBound(nums, i - k);
            int r = RightBound(nums, i + k);
            int best = 0;
            if (numCount.TryGetValue(i, out int value))
            {
                best = Math.Min(r - l + 1, value + numOperations);
            }
            else
            {
                best = Math.Min(r - l + 1, numOperations);
            }
            ans = Math.Max(ans, best);
        }

        return ans;
    }

    int LeftBound(int[] nums, int val)
    {
        int n = nums.Length;
        int low = 0, high = n - 1, ans = n - 1;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (nums[mid] >= val)
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

    int RightBound(int[] nums, int val)
    {
        int low = 0, high = nums.Length - 1, ans = 0;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (nums[mid] <= val)
            {
                ans = mid;
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }
        return ans;
    }
}