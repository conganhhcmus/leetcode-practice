public class Solution
{
    public int MaxChunksToSorted(int[] arr)
    {
        int n = arr.Length;
        int[] maxPrefix = [.. arr];
        int[] minSuffix = [.. arr];
        for (int i = 1; i < n; i++)
        {
            maxPrefix[i] = Math.Max(maxPrefix[i], maxPrefix[i - 1]);
        }

        for (int i = n - 1; i > 0; i--)
        {
            minSuffix[i - 1] = Math.Min(minSuffix[i - 1], minSuffix[i]);
        }

        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            if (i == 0 || minSuffix[i] > maxPrefix[i - 1])
            {
                ans++;
            }
        }

        return ans;
    }
}