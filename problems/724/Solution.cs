namespace Problem_724;

public class Solution
{
    public static void Execute()
    {
        Solution solution = new Solution();
        int[] nums = [1, 7, 3, 6, 5, 6];
        Console.WriteLine(solution.PivotIndex(nums));
    }
    public int PivotIndex(int[] nums)
    {
        int totalSum = nums.Sum();
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (sum * 2 == totalSum - nums[i]) return i;
            sum += nums[i];
        }

        return -1;
    }
}