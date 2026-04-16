public class Solution
{
    int mod = (int)1e9 + 7;

    long Pow(long a, long b)
    {
        long ans = 1;
        while (b > 0)
        {
            if ((b & 1) != 0)
            {
                ans = ans * a % mod;
            }
            a = a * a % mod;
            b >>= 1;
        }
        return ans;
    }

    public int MaxValue(int[] nums1, int[] nums0)
    {
        int n = nums1.Length;
        int[] index = new int[n];
        for (int i = 0; i < n; i++)
        {
            index[i] = i;
        }

        Array.Sort(
            index,
            (i, j) =>
            {
                if (nums0[i] == 0 && nums0[j] == 0)
                    return nums1[j] - nums1[i];
                if (nums0[i] == 0)
                    return -1;
                if (nums0[j] == 0)
                    return 1;
                if (nums1[i] == nums1[j])
                    return nums0[i] - nums0[j];
                return nums1[j] - nums1[i];
            }
        );

        long ans = 0;

        foreach (var id in index)
        {
            // shift nums1[id] = ans * 2 ^ nums1[id]
            // add 11...11 (nums1[id] ones) = 2 ^ nums1[id] - 1
            ans = (ans * Pow(2, nums1[id]) + Pow(2, nums1[id]) - 1) % mod;

            ans = (ans * Pow(2, nums0[id])) % mod;
        }

        if (ans < 0)
            ans = (ans + mod) % mod;
        return (int)ans;
    }
}
