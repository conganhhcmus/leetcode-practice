#if DEBUG
namespace Problems_164;
#endif

public class Solution
{
    public int MaximumGap(int[] nums)
    {
        int n = nums.Length;
        if (n < 2) return 0;
        RadixSort(nums);
        int ret = 0;
        for (int i = 1; i < n; i++)
        {
            ret = Math.Max(ret, nums[i] - nums[i - 1]);
        }

        return ret;
    }

    void RadixSort(int[] nums)
    {
        int n = nums.Length;
        int place = 1;
        // nums[i] <= 10^9 ~ 10 digits
        int[] counts = new int[10];
        for (int i = 0; i < 10; i++)
        {
            Array.Clear(counts);
            foreach (int num in nums)
            {
                int key = (num / place) % 10;
                counts[key]++;
            }

            int startIdx = 0;
            for (int j = 0; j < 10; j++)
            {
                int count = counts[j];
                counts[j] = startIdx;
                startIdx += count;
            }
            int[] sortedArray = new int[n];
            foreach (int num in nums)
            {
                int key = (num / place) % 10;
                sortedArray[counts[key]] = num;
                counts[key]++;
            }

            Array.Copy(sortedArray, nums, n);
            place *= 10;
        }
    }
}