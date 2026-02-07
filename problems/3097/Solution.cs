public class Solution
{
    public int MinimumSubarrayLength(int[] nums, int k)
    {
        return MinimumSubarrayLength_SlidingWindow(nums, k);
        //return MinimumSubarrayLength_Dictionary(nums, k);
    }

    private int MinimumSubarrayLength_SlidingWindow(int[] nums, int k)
    {
        int minLen = int.MaxValue;
        int start = 0;
        int end = 0;
        int[] bitCounts = new int[32];
        while (end < nums.Length)
        {
            UpdateBitCounts(bitCounts, nums[end], 1);
            while (start <= end && ConvertBitCountsToNumber(bitCounts) >= k)
            {
                minLen = Math.Min(minLen, end - start + 1);
                UpdateBitCounts(bitCounts, nums[start], -1);
                start++;
            }
            end++;
        }
        return minLen == int.MaxValue ? -1 : minLen;
    }

    private void UpdateBitCounts(int[] bitCounts, int number, int delta)
    {
        for (int bitPosition = 0; bitPosition < 32; bitPosition++)
        {
            // Check if bit is set at current position
            if (((number >> bitPosition) & 1) != 0)
            {
                bitCounts[bitPosition] += delta;
            }
        }
    }

    private int ConvertBitCountsToNumber(int[] bitCounts)
    {
        int result = 0;
        for (int bitPosition = 0; bitPosition < 32; bitPosition++)
        {
            if (bitCounts[bitPosition] != 0)
            {
                result |= 1 << bitPosition;
            }
        }
        return result;
    }

    private int MinimumSubarrayLength_Dictionary(int[] nums, int k)
    {
        int minLen = int.MaxValue;
        Dictionary<int, int> prev = [];
        Dictionary<int, int> current = [];
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] >= k) return 1;
            foreach (var pair in prev)
            {
                int len = pair.Value + 1;
                int val = nums[i] | pair.Key;
                if (len < minLen)
                {
                    current[val] = len;
                    if (val >= k) minLen = len;
                }
            }
            current[nums[i]] = 1;
            prev = current;
            current = [];
        }

        return minLen == int.MaxValue ? -1 : minLen;
    }
}