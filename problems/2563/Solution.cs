namespace Problem_2563;

public class Solution
{
    public static void Execute()
    {
        int[] nums = [1, 7, 9, 2, 5];
        int lower = 11;
        int upper = 11;
        var solution = new Solution();
        Console.WriteLine(solution.CountFairPairs(nums, lower, upper));
    }

    public long CountFairPairs(int[] nums, int lower, int upper)
    {
        Array.Sort(nums);
        return CountLess(nums, upper) - CountLess(nums, lower - 1);
    }

    private long CountLess(int[] nums, int sum)
    {
        long res = 0;
        for (int i = 0, j = nums.Length - 1; i < j; ++i)
        {
            while (i < j && nums[i] + nums[j] > sum)
                --j;
            res += j - i;
        }
        return res;
    }
}