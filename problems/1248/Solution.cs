public class Solution
{
    public int NumberOfSubarrays(int[] a, int k)
    {
        // count[i] - count[j] == k
        // count[j] = count[i] - k
        int n = a.Length;
        int[] count = new int[n + 1];
        for (int i = 0; i < n; ++i)
        {
            count[i + 1] = count[i] + a[i] % 2;
        }
        int ret = 0;
        int[] map = new int[50001];
        for (int i = 0; i <= n; i++)
        {
            if (count[i] >= k)
            {
                ret += map[count[i] - k];
            }
            map[count[i]]++;
        }

        return ret;
    }
}