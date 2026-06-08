public class Solution
{
    public bool ConsecutiveSetBits(int n)
    {
        int count = 0;
        int pairs = 0;
        for (int i = 0; i < 32; i++)
        {
            bool isSetBit = (n & (1 << i)) != 0;
            if (isSetBit) count++;
            else count = 0;
            if (count > 1) pairs++;
        }
        return pairs == 1;
    }
}
