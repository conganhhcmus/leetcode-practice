namespace Problem_1497;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        int[] arr = [-1, -1, -1, -1, 2, 2, -2, -2];
        int k = 3;
        Console.WriteLine(solution.CanArrange(arr, k));
    }
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