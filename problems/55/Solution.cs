public class Solution
{
    public bool CanJump(int[] nums)
    {
        int max = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (i > max) return false;
            max = Math.Max(max, i + nums[i]);
        }

        return true;
    }
}