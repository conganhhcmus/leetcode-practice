public class Solution
{
    public int[] LexSmallestNegatedPerm(int n, long target)
    {
        // sum - 2 * t = target
        // t = (sum - target) / 2
        long sum = 1L * n * (n + 1) / 2;
        if (sum < target || target < -sum) return [];
        long t = sum - target;
        if (t % 2 != 0) return [];
        t /= 2;
        int[] ans = new int[n];
        for (int i = 0; i < n; i++) ans[i] = i + 1;
        while (t > 0)
        {
            while (n > t) n--;
            ans[n - 1] *= -1;
            t -= n;
            n--;
        }
        if (t < 0) return [];
        Array.Sort(ans, (a, b) => a - b);
        return ans;
    }
}
