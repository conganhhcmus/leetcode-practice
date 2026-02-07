public class Solution
{
    public bool IsOneBitCharacter(int[] bits)
    {
        int i = 0;
        while (i < bits.Length - 1)
        {
            i += bits[i] + 1;
        }
        return i == bits.Length - 1;
    }
}