public class Solution
{
    public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
    {
        Dictionary<int, int> map = [];
        int n = nums1.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int key = nums1[i] + nums2[j];
                map[key] = map.GetValueOrDefault(key, 0) + 1;
            }
        }
        int ans = 0;
        for (int k = 0; k < n; k++)
        {
            for (int l = 0; l < n; l++)
            {
                int key = -1 * (nums3[k] + nums4[l]);
                ans += map.GetValueOrDefault(key, 0);
            }
        }
        return ans;
    }
}