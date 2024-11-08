namespace Problem_1829;

public class Solution
{
    public static void Execute()
    {
        int[] nums = [2, 3, 4, 7];
        int maximumBit = 3;
        var solution = new Solution();
        Console.WriteLine($"[{string.Join(",", solution.GetMaximumXor(nums, maximumBit))}]");
    }
    public int[] GetMaximumXor(int[] nums, int maximumBit)
    {
        int maxK = (1 << maximumBit) - 1;
        int n = nums.Length;
        int[] result = new int[n];
        int xor = 0; // a ^ 0 = a
        for (int i = 0; i < n; i++)
        {
            xor ^= nums[i];
            result[n - i - 1] = xor ^ maxK; // a ^ b = c => a ^ c = b
        }
        return result;
    }
}