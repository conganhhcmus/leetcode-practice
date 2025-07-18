#if DEBUG
namespace Problems_2163;
#endif

public class Solution
{
    public long MinimumDifference(int[] nums)
    {
        int n = nums.Length / 3;
        long ans = long.MaxValue;
        PriorityQueue<int, int> pqLeft = new();
        PriorityQueue<int, int> pqRight = new();
        long[] minSumLeft = new long[3 * n];
        Array.Fill(minSumLeft, long.MaxValue / 3);
        long[] maxSumRight = new long[3 * n];
        Array.Fill(maxSumRight, long.MinValue / 3);
        long sum = 0;
        for (int i = 0; i < n; i++)
        {
            pqLeft.Enqueue(nums[i], -nums[i]);
            sum += nums[i];
            minSumLeft[i] = sum;
        }
        for (int i = n; i < 2 * n; i++)
        {
            pqLeft.Enqueue(nums[i], -nums[i]);
            sum += nums[i] - pqLeft.Dequeue();
            minSumLeft[i] = sum;
        }
        sum = 0;
        for (int i = 3 * n - 1; i >= 2 * n; i--)
        {
            pqRight.Enqueue(nums[i], nums[i]);
            sum += nums[i];
            maxSumRight[i] = sum;
        }
        for (int i = 2 * n - 1; i >= n; i--)
        {
            pqRight.Enqueue(nums[i], nums[i]);
            sum += nums[i] - pqRight.Dequeue();
            maxSumRight[i] = sum;
        }

        for (int i = n - 1; i < 2 * n; i++)
        {
            ans = Math.Min(ans, minSumLeft[i] - maxSumRight[i + 1]);
        }

        return ans;
    }
}