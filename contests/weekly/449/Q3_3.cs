public class Solution
{
    public long MaxScore(int n, int[][] edges)
    {
        bool isCycle = (n == edges.Length);
        // // 1 3 2 = f(3) = 9
        // // 1 3 4 2 = f(4) = f(3) + 4*3 + 4*2 - 2*3
        // // 1 3 5 4 2 = f(5) = f(4) + 5*4 + 5*3 - 4*3
        // // 1 3 5 6 4 2 = f(6) = f(5) + 6*5 + 6*4 - 5*4
        // // f(n) = f(n-1) + n * (n-1) + n * (n-2) - (n-1)*(n-2)
        // // f(n) = f(n-1) + n^2 - n + n^2 - 2n - (n^2 - 3n + 2)
        // // f(n) = f(n-1) + n^2 - 2
        // // f(0) = 1
        // long[] dp = new long[n + 1];
        // dp[0] = 1;
        // for (int i = 1; i <= n; i++)
        // {
        //     dp[i] = dp[i - 1] + (1L * i * i) - 2L;
        // }


        // return dp[n] + (isCycle ? 2L : 0L);

        // optimize
        // f(n) = f(n-1) + n^2-2
        // f(n) = f(n-2) + n^2 + (n-1)^2 - 2*2
        // f(n) = n^2 + (n-1)^2 +... + 1^2 - 2*n
        // f(n) = sum (i^2) where i from 0 to n - 2*n
        // f(n) = sum (i^2) where i form 1 to n - 2*n + 1
        // f(n) = n*(n+1)*(2n+1)/6 - 2*n +1
        long ret = 1L * n * (n + 1) * (2L * n + 1) / 6 - 2L * n + 1;
        if (isCycle) ret += 2;
        return ret;
    }
}