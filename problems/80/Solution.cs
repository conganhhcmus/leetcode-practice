namespace Problem_80;
public class Solution
{
    public static void Execute()
    {
        int[] nums = [0, 0, 1, 1, 1, 1, 2, 3, 3];
        var solution = new Solution();
        int k = solution.RemoveDuplicates(nums);
        Console.WriteLine(k);
        Console.WriteLine($"[{string.Join(",", nums[..k])}]");
    }
    public int RemoveDuplicates(int[] nums)
    {
        if (nums.Length <= 2) return nums.Length;
        int k = 2;
        for (int i = 2; i < nums.Length; i++)
        {
            if (nums[i] != nums[k - 2])
            {
                nums[k] = nums[i];
                k++;
            }
        }

        return k;
    }
}