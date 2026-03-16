public class Solution
{
    int MAX = 100_000;
    public int MinCost(int[] nums1, int[] nums2)
    {
        int[] count = new int[MAX];
        int n = nums1.Length;
        for (int i = 0; i < n; i++)
        {
            count[nums1[i]]++;
            count[nums2[i]]--;
        }
        int ans = 0;
        for (int i = 0; i < MAX; i++)
        {
            if (count[i] % 2 != 0) return -1;
            if (count[i] > 0) ans += count[i] / 2;
        }
        return ans;
    }
}