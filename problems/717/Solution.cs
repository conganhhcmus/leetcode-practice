#if DEBUG
namespace Problems_717;
#endif

public class Solution
{
    public bool IsOneBitCharacter(int[] bits)
    {
        int n = bits.Length;
        if (n == 1) return true;
        bool[] dp = new bool[n];
        dp[0] = true;
        dp[1] = bits[0] == 0;
        for (int i = 2; i < n; i++)
        {
            if (bits[i - 1] == 1 && bits[i - 2] == 0)
            {
                dp[i] = false;
            }
            else if (bits[i - 1] == 0)
            {
                dp[i] |= dp[i - 1];
                dp[i] |= dp[i - 2];
            }
            else
            {
                dp[i] |= dp[i - 2];
            }
        }
        return dp[n - 1];
    }
}