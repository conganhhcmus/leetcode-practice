namespace Problem_136;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        int[] nums = [2, 2, 1];
        Console.WriteLine(solution.SingleNumber(nums));
    }
    public int SingleNumber(int[] nums)
    {
        int ans = 0;
        foreach (var num in nums)
        {
            ans ^= num;
        }
        return ans;
    }
}