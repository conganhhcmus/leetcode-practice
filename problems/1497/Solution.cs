namespace Problem_1497;

public class Solution
{
    public bool CanArrange(int[] arr, int k)
    {
        int[] dp = new int[k];

        foreach (int num in arr)
        {
            int key = (num % k + k) % k;
            dp[key]++;
        }

        if (dp[0] % 2 != 0) return false;

        for (int i = 1; i <= k / 2; i++)
        {
            if (dp[i] != dp[k - i]) return false;
        }

        return true;
    }
}