namespace Problem_217;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        int[] nums = [1, 2, 3, 1];
        Console.WriteLine(solution.ContainsDuplicate(nums));
    }
    public bool ContainsDuplicate(int[] nums)
    {
        HashSet<int> hashSet = [];
        for (int i = 0; i < nums.Length; i++)
        {
            if (!hashSet.Add(nums[i])) return true;
        }
        return false;
    }
}