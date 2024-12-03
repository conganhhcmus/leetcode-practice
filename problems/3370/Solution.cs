namespace Problem_3370;
public class Solution
{
    public int SmallestNumber(int n)
    {
        int i = 1;
        while (i < n)
        {
            n |= i;
            i <<= 1;
        }
        return n;
    }
}