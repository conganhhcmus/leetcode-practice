public class Solution
{
    public int BinaryGap(int n)
    {
        int prev = -1;
        int ans = 0;
        for (int i = 0; i < 32; i++)
        {
            if ((n & (1 << i)) != 0)
            {
                if (prev != -1)
                {
                    ans = Math.Max(ans, i - prev);
                }
                prev = i;
            }
        }
        return ans;
    }
}