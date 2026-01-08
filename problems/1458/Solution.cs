#if DEBUG
namespace Problems_1458;
#endif

public class Solution
{
    public int MaxDotProduct(int[] nums1, int[] nums2)
    {
        return DP(0, 0, nums1, nums2);
    }

    Dictionary<(int, int), int> memo = [];

    int DP(int p1, int p2, int[] nums1, int[] nums2)
    {
        int n1 = nums1.Length, n2 = nums2.Length;
        if (p1 >= n1 || p2 >= n2) return int.MinValue / 2;

        var key = (p1, p2);
        if (memo.TryGetValue(key, out int cache)) return cache;
        int ans = int.MinValue;
        ans = Math.Max(ans, DP(p1 + 1, p2, nums1, nums2));
        ans = Math.Max(ans, DP(p1, p2 + 1, nums1, nums2));
        ans = Math.Max(ans, nums1[p1] * nums2[p2] + Math.Max(0, DP(p1 + 1, p2 + 1, nums1, nums2)));

        return memo[key] = ans;
    }
}