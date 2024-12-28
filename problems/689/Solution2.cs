#if DEBUG
namespace Problems_689_2;
#endif

public class Solution
{
    public int[] MaxSumOfThreeSubarrays(int[] nums, int k)
    {
        int n = nums.Length;
        Span<int> sums = stackalloc int[n - k + 1];
        int currSum = 0;
        for (int i = 0; i < k; i++) currSum += nums[i];
        sums[0] = currSum;
        for (int i = 1; i < n - k + 1; i++)
        {
            currSum += nums[i + k - 1] - nums[i - 1];
            sums[i] = currSum;
        }
        Span<int> leftMaxIdx = stackalloc int[n - k + 1];
        Span<int> rightMaxIdx = stackalloc int[n - k + 1];
        int maxIdx = 0;
        for (int i = 0; i < n - k + 1; i++)
        {
            if (sums[i] > sums[maxIdx]) maxIdx = i;
            leftMaxIdx[i] = maxIdx;
        }
        maxIdx = n - k;
        for (int i = n - k; i >= 0; i--)
        {
            if (sums[i] >= sums[maxIdx]) maxIdx = i;
            rightMaxIdx[i] = maxIdx;
        }

        int[] result = new int[3];
        int maxSum = 0;
        for (int i = k; i < n - 2 * k + 1; i++)
        {
            int leftIdx = leftMaxIdx[i - k];
            int rightIdx = rightMaxIdx[i + k];
            currSum = sums[leftIdx] + sums[i] + sums[rightIdx];
            if (currSum > maxSum)
            {
                maxSum = currSum;
                result[0] = leftIdx;
                result[1] = i;
                result[2] = rightIdx;
            }
        }

        return result;
    }
}