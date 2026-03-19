public class Solution
{
    public int GetSum(int a, int b)
    {
        int ans = 0;
        int overflow = 0;
        for (int i = 0; i < 32; i++)
        {
            int bitA = (a >> i) & 1;
            int bitB = (b >> i) & 1;
            int bit = bitA ^ bitB ^ overflow;
            if (bit == 1)
            {
                overflow = bitA & bitB & overflow;
            }
            else
            {
                overflow = bitA | bitB | overflow;
            }

            ans |= bit << i;
        }
        return ans;
    }
}