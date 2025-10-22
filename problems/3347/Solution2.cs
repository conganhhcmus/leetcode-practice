#if DEBUG
namespace Problems_3347_2;
#endif

public class Solution
{
    public int MaxFrequency(int[] nums, int k, int numOperations)
    {
        int n = nums.Length;
        Array.Sort(nums);
        HashSet<int> modes = [];
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
            modes.Add(nums[i]);
            modes.Add(nums[i] - k);
            modes.Add(nums[i] + k);
        }

        numCount[nums[lastNumIndex]] = n - lastNumIndex;
        ans = Math.Max(ans, n - lastNumIndex);

        foreach (int val in modes)
        {
            int l = LeftBound(nums, val - k);
            int r = RightBound(nums, val + k);
            ans = Math.Max(ans, Math.Min(r - l + 1, numOperations + numCount.GetValueOrDefault(val, 0)));
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