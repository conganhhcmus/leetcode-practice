#if DEBUG
namespace Problems_137_2;
#endif

public class Solution
{
    public int SingleNumber(int[] nums)
    {
        int n = nums.Length;
        int ones = 0, twos = 0;
        /*
        a & ~0 = a
        a & ~a = 0
        ones = (ones ^ nums[i]) & ~twos;
            ones ^ nums[i]: Toggles the bits in ones (if a bit in nums[i] is 1, it flips it).
            & ~twos: Ensures that if a bit is already in twos, it is removed from ones.
        
        twos = (twos ^ nums[i]) & ~ones;
            twos ^ nums[i]: Toggles the bits in twos (same as before).
            & ~ones: Ensures that if a bit has moved to ones, it is removed from twos.
        */
        for (int i = 0; i < n; i++)
        {
            ones = (ones ^ nums[i]) & ~twos;
            twos = (twos ^ nums[i]) & ~ones;
        }
        return ones;
    }
}