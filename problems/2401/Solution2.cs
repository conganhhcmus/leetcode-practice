#if DEBUG
namespace Problems_2401_2;
#endif

public class Solution
{
    public int LongestNiceSubarray(int[] nums)
    {
        // nums[i] max is 10^9 ~ 30 bits, so if each element in nice subarray set 1 bit, it will max length is 30. 
        int low = 1, high = 30, ans = 1;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (CheckNice(nums, mid))
            {
                ans = mid;
                low = mid + 1;
            }
            else high = mid - 1;
        }
        return ans;
    }

    bool CheckNice(int[] nums, int mid)
    {
        // brute force all subarray
        int n = nums.Length;
        for (int start = 0; start + mid <= n; start++)
        {
            bool isBad = false;
            int bitMask = 0;
            for (int i = start; i < start + mid; i++)
            {
                if ((bitMask & nums[i]) != 0)
                {
                    isBad = true;
                    break;
                }

                bitMask |= nums[i];
            }
            if (!isBad) return true;
        }
        return false;
    }
}