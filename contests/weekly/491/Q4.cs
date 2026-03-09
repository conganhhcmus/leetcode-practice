public class Solution
{
    public long CountSubarrays(int[] nums, int k, int m)
    {
        long ans = 0;
        int n = nums.Length;
        int max = 100001;
        // use 2 slide windows
        // one for exactly k distinct
        // one for at most k element has >= m freq
        int[] freq1 = new int[max];
        int uni = 0;
        int l1 = 0;
        int[] freq2 = new int[max];
        int count = 0;
        int l2 = 0;

        for (int i = 0; i < n; i++)
        {
            int val = nums[i];
            freq1[val]++;
            if (freq1[val] == 1) uni++;
            while (uni > k)
            {
                freq1[nums[l1]]--;
                if (freq1[nums[l1]] == 0) uni--;
                l1++;
            }

            freq2[val]++;
            if (freq2[val] == m) count++;
            while (count >= k)
            {
                if (freq2[nums[l2]] == m) count--;
                freq2[nums[l2]]--;
                l2++;
            }

            if (l2 > l1)
            {
                ans += l2 - l1;
            }
        }

        return ans;
    }
}