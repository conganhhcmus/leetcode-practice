namespace Problem_2461;

public class Solution
{
    public static void Execute()
    {
        int[] nums = [1, 5, 4, 2, 9, 9, 9];
        int k = 3;
        var solution = new Solution();
        Console.WriteLine(solution.MaximumSubarraySum(nums, k));
    }
    public long MaximumSubarraySum(int[] nums, int k)
    {
        long maxSum = 0, sum = 0;
        HashSet<int> hashSet = [];
        int n = nums.Length;
        int l = 0, r = 0;

        while (r < n)
        {
            if (hashSet.Count >= k)
            {
                hashSet.Remove(nums[l]);
                sum -= nums[l];
                l++;
            }

            while (!hashSet.Add(nums[r]))
            {
                hashSet.Remove(nums[l]);
                sum -= nums[l];
                l++;
            }
            sum += nums[r];
            if (hashSet.Count == k)
            {
                maxSum = Math.Max(maxSum, sum);
            }

            r++;
        }

        return maxSum;
    }
}