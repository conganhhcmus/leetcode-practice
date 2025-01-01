#if DEBUG
namespace Problems_1422;
#endif

public class Solution
{
    public int MaxScore(string s)
    {
        int n = s.Length;
        int[][] prefixSum = new int[n + 1][];
        prefixSum[0] = [0, 0];
        for (int i = 1; i <= n; i++)
        {
            prefixSum[i] = [prefixSum[i - 1][0] + ('1' - s[i - 1]), prefixSum[i - 1][1] + (s[i - 1] - '0')];
        }
        int ans = 0;
        for (int i = 1; i < n; i++)
        {
            ans = Math.Max(ans, prefixSum[i][0] + prefixSum[n][1] - prefixSum[i][1]);
        }
        return ans;
    }
}