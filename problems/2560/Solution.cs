#if DEBUG
namespace Problems_2560;
#endif

public class Solution
{
    public int MinCapability(int[] nums, int k)
    {
        int min = int.MaxValue, max = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            min = Math.Min(min, nums[i]);
            max = Math.Max(max, nums[i]);
        }
        int low = min, high = max, ans = 0;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (Ok(nums, k, mid))
            {
                ans = mid;
                high = mid - 1;
            }
            else low = mid + 1;
        }

        return ans;
    }

    bool Ok(int[] nums, int k, int mid)
    {
        // [i1,i2,i3,i4,...]
        // if all of them are valid to choose
        // if choose i1 and check [i3,i4,...] >= skip i1 choose i2 and [i4,...]
        // i1 + [i3,i4..] >= i2 + [i4,...]
        // ~ 1 + [i3,i4,...] >= 1 + [i4,...]
        // because [i3,i4,..] was covered [i4,...]
        int count = 0, i = 0;
        while (i < nums.Length)
        {
            if (nums[i] <= mid)
            {
                count++;
                i += 2;
            }
            else i++;
        }
        return count >= k;
    }
}