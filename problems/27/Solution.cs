namespace Problem_27;
public class Solution
{
    public static void Execute()
    {
        int[] nums = [3, 2, 2, 3];
        int val = 3;
        var solution = new Solution();
        var k = solution.RemoveElement(nums, val);
        Console.WriteLine(k);
        Console.WriteLine($"[{string.Join(", ", nums[..k])}]");
    }
    public int RemoveElement(int[] nums, int val)
    {
        int[] tmp = [.. nums];
        int k = 0;
        for (int i = 0; i < tmp.Length; i++)
        {
            if (tmp[i] != val)
            {
                nums[k] = tmp[i];
                k++;
            }
        }
        return k;
    }
}