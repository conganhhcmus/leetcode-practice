namespace Problem_1318;

public class Solution
{
    public int MinFlips(int a, int b, int c)
    {
        int diffBits = (a | b) ^ c;
        int flipCount = int.PopCount(diffBits);
        while (diffBits > 0)
        {
            if ((diffBits & 1) != 0)
            {
                flipCount += ((a & 1) + (b & 1)) / 2;
            }
            diffBits >>= 1;
            a >>= 1;
            b >>= 1;
        }
        return flipCount;
    }
}