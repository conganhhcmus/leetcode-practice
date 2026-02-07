public class Solution
{
    public int LargestInteger(int[] nums, int k)
    {
        int n = nums.Length;
        int[] freq = new int[51];
        for (int i = 0; i + k <= n; i++)
        {
            HashSet<int> set = [];
            for (int j = 0; j < k; j++)
            {
                if (set.Add(nums[i + j])) freq[nums[i + j]]++;
            }
        }

        return GetMax(freq);
    }

    private int GetMax(int[] freq)
    {
        int ans = -1;
        for (int i = 0; i < 51; i++)
        {
            if (freq[i] == 1) ans = Math.Max(ans, i);
        }
        return ans;
    }
}