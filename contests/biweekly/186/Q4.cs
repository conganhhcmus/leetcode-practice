public class Solution
{
    public int InterleaveCharacters(string word1, string word2, string target)
    {
        int n1 = word1.Length, n2 = word2.Length, n = target.Length;
        int MOD = 1_000_000_007;

        long?[,,,] memo = new long?[n1 + 1, n2 + 1, n + 1, 4];
        return (int)DP(-1, -1, 0, 0);
        long DP(int last1, int last2, int k, int mask)
        {
            if (k == n) return mask == 3 ? 1 : 0;
            int i1 = last1 + 1;
            int i2 = last2 + 1;

            if (memo[i1, i2, k, mask].HasValue) return memo[i1, i2, k, mask].Value;
            long ans = 0;
            char need = target[k];
            for (int i = last1 + 1; i < n1; i++)
            {
                if (word1[i] == need)
                {
                    ans += DP(i, last2, k + 1, mask | 1);
                    ans %= MOD;
                }
            }
            for (int j = last2 + 1; j < n2; j++)
            {
                if (word2[j] == need)
                {
                    ans += DP(last1, j, k + 1, mask | 2);
                    ans %= MOD;
                }
            }
            memo[i1, i2, k, mask] = ans;
            return ans;
        }
    }
}
