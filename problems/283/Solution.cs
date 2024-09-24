namespace Problem_283;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        int[] nums = [0, 1, 0, 3, 12];
        solution.MoveZeroes(nums);

        Console.WriteLine($"[{string.Join(",", nums)}]");
    }
    public void MoveZeroes(int[] nums)
    {
        int lastZeroPosition = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                (nums[lastZeroPosition], nums[i]) = (nums[i], nums[lastZeroPosition]);
                lastZeroPosition++;
            }
        }
    }
}