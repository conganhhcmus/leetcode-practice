public class Solution
{
    public int MinBitFlips(int start, int goal)
    {
        // Bitwise XOR returns 1 when two bits are different,
        // so we can use it to find the differing bits between start and goal.
        int tmp = start ^ goal;

        int ans = 0;
        while (tmp > 0)
        {
            // Bitwise AND returns 1 when bits are the same,
            // so we can use it with 1 to check if the last bit is set (turned on).
            ans += tmp & 1;

            // Bitwise right shift shifts all bits in 'tmp' to the right by 1.
            tmp >>= 1;
        }

        return ans;
    }
}