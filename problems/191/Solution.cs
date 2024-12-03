namespace Problems_191;

public class Solution
{
    public int HammingWeight(int n)
    {
        int ans = 0;
        while (n > 0)
        {
            ans += n & 1;
            n >>= 1;
        }

        return ans;
    }
}