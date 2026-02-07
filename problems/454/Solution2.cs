public class Solution
{
    public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
    {
        Dictionary<int, int> freq1 = GetFrequencyMap(nums1);
        Dictionary<int, int> freq2 = GetFrequencyMap(nums2);
        Dictionary<int, int> freq3 = GetFrequencyMap(nums3);
        Dictionary<int, int> freq4 = GetFrequencyMap(nums4);

        Dictionary<int, int> map = [];
        foreach (var (n1, c1) in freq1)
        {
            foreach (var (n2, c2) in freq2)
            {
                int sum = n1 + n2;
                map[sum] = map.GetValueOrDefault(sum, 0) + c1 * c2;
            }
        }
        int ans = 0;
        foreach (var (n3, c3) in freq3)
        {
            foreach (var (n4, c4) in freq4)
            {
                int sum = n3 + n4;
                ans += map.GetValueOrDefault(-sum, 0) * c3 * c4;
            }
        }

        return ans;
    }

    Dictionary<int, int> GetFrequencyMap(int[] nums)
    {
        Dictionary<int, int> map = [];
        foreach (int num in nums)
        {
            map[num] = map.GetValueOrDefault(num, 0) + 1;
        }
        return map;
    }
}