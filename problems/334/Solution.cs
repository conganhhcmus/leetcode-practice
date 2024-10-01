namespace Problem_334;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        int[] nums = [1, 2, 3, 4, 5];
        Console.WriteLine(solution.IncreasingTriplet(nums));
    }
    public bool IncreasingTriplet(int[] nums)
    {
        if (nums.Length < 3) return false;
        int min1 = int.MaxValue, min2 = int.MaxValue;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] <= min1) min1 = nums[i];
            else if (nums[i] <= min2) min2 = nums[i];
            else return true;
        }
        return false;
    }
}