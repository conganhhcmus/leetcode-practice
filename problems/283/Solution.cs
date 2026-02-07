public class Solution
{
    public void MoveZeroes(int[] nums)
    {
        int lastZeroPosition = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                (nums[lastZeroPosition], nums[i]) = (nums[i], nums[lastZeroPosition]);
                lastZeroPosition++;
            }
        }
    }
}