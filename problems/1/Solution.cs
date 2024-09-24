namespace Problem_1;
public class Solution
{
    public static void Execute()
    {
        var nums = new[] { 2, 7, 11, 15 };
        var target = 9;
        var solution = new Solution();

        var res = solution.TwoSum(nums, target);
        Console.WriteLine($"[{res[0]}, {res[1]}]");
    }
    public int[] TwoSum(int[] nums, int target)
    {
        var p1 = 0;
        var p2 = 1;
        while (p1 < nums.Length)
        {
            while (p2 < nums.Length)
            {
                if (nums[p1] + nums[p2] == target)
                {
                    return new[] { p1, p2 };
                }
                p2++;
            }
            p1++;
            p2 = p1 + 1;
        }
        return new[] { p1, p2 };
    }
}