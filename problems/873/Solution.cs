public class Solution
{
    public int LenLongestFibSubseq(int[] arr)
    {
        int ans = 0;
        int n = arr.Length;
        Dictionary<int, int> map = [];
        for (int i = 0; i < n; i++) map[arr[i]] = i;
        // f(i, j) : length of longest fibonacci sequence ending with arr[i] and second largest at j index
        // f(i, j) = f(j, k) + 1, where k = map[arr[i] - arr[j]] and arr[k] < arr[j] < arr[i]

        int[,] dp = new int[n, n];
        for (int i = 2; i < n; i++)
        {
            for (int j = 1; j < i; j++)
            {
                int remain = arr[i] - arr[j];
                if (remain < arr[j] && map.TryGetValue(remain, out int k))
                {
                    dp[i, j] = dp[j, k] + 1;
                    ans = Math.Max(ans, dp[i, j]);
                }
            }
        }

        return ans == 0 ? 0 : ans + 2;
    }
}