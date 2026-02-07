public class Solution
{
    public int SubarraysDivByK(int[] a, int k)
    {
        int ret = 0;
        int n = a.Length;
        // sum of a[l..r] % k == 0
        // (sum[r] - sum[l]) % k == 0 where r > l
        // sum[r] % k == sum[l] % k
        int[] sum = new int[n + 1];
        for (int i = 0; i < n; ++i)
        {
            sum[i + 1] = ((sum[i] + a[i]) % k + k) % k; // +k due to negative modulo
        }
        int[] map = new int[k];
        for (int i = 0; i <= n; ++i)
        {
            ret += map[sum[i]];
            map[sum[i]]++;
        }

        return ret;
    }
}