namespace Problem_169;
public class Solution
{
    public static void Execute()
    {
        int[] nums = [3, 2, 3];
        var solution = new Solution();
        Console.WriteLine(solution.MajorityElement(nums));
    }
    public int MajorityElement(int[] nums)
    {
        int majorityElement = nums[0];
        int count = 0;

        foreach (int num in nums)
        {
            if (count == 0)
            {
                majorityElement = num;
            }

            count += (num == majorityElement) ? 1 : -1;
        }

        return majorityElement;
    }
}