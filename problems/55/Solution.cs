namespace Problem_55;
public class Solution
{
    public static void Execute()
    {
        int[] nums = [2, 0, 0];
        var solution = new Solution();
        Console.WriteLine(solution.CanJump(nums));
    }
    public bool CanJump(int[] nums)
    {
        int max = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (i > max) return false;
            max = Math.Max(max, i + nums[i]);
        }

        return true;
    }
}