public class Solution
{
    public long NumberOfWays(string s)
    {
        long comb1 = 0, comb0 = 0, comb10 = 0, comb01 = 0;
        long ret = 0;
        foreach (char c in s)
        {
            if (c == '0')
            {
                ret += comb01;
                comb0++;
                comb10 += comb1;
            }
            else
            {
                ret += comb10;
                comb1++;
                comb01 += comb0;
            }
        }
        return ret;
    }
}