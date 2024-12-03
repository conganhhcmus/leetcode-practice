namespace Problem_1;

public class Solution
{
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
                    return [p1, p2];
                }
                p2++;
            }
            p1++;
            p2 = p1 + 1;
        }
        return [p1, p2];
    }
}