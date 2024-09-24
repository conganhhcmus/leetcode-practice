namespace Problem_26;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        int[] nums = [1, 1, 2];
        Console.WriteLine(solution.RemoveDuplicates(nums));
        Console.WriteLine(string.Join(", ", nums));
    }
    public int RemoveDuplicates(int[] nums)
    {
        var k = 1;
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i - 1] != nums[i])
            {
                nums[k] = nums[i];
                k++;
            }
        }
        return k;
    }
}