namespace Problem_189;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        int[] nums = [1, 2, 3, 4, 5, 6];
        int k = 1;
        solution.Rotate(nums, k);
        Console.WriteLine($"[{string.Join(",", nums)}]");
    }

    public void Rotate(int[] nums, int k)
    {
        k %= nums.Length;
        Reverse(nums, 0, nums.Length - 1);
        Reverse(nums, 0, k - 1);
        Reverse(nums, k, nums.Length - 1);
    }

    private void Reverse(int[] nums, int left, int right)
    {
        int temp;
        while (left < right)
        {
            temp = nums[left];
            nums[left] = nums[right];
            nums[right] = temp;
            left++;
            right--;
        }
    }

    public void Rotate2(int[] nums, int k)
    {
        if (nums.Length <= 1 || k % nums.Length == 0) return;
        int gap = nums.Length - (k % nums.Length);

        int[] tmp = [.. nums[gap..], .. nums[..gap]];

        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = tmp[i];
        }
    }
}