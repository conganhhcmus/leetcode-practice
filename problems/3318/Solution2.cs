#if DEBUG
namespace Problems_3318_2;
#endif

public class Solution
{
    public int[] FindXSum(int[] nums, int k, int x)
    {
        int n = nums.Length;
        int[] ans = new int[n - k + 1];
        for (int i = 0; i < n - k + 1; i++)
        {
            Dictionary<int, int> count = [];
            for (int j = i; j < i + k; j++)
            {
                if (count.ContainsKey(nums[j]))
                {
                    count[nums[j]]++;
                }
                else
                {
                    count[nums[j]] = 1;
                }
            }

            List<int[]> freq = [];
            foreach (var pair in count)
            {
                freq.Add([pair.Key, pair.Value]);
            }
            freq.Sort((a, b) =>
            {
                if (a[1] == b[1]) return b[0] - a[0];
                return b[1] - a[1];
            });

            int xSum = 0;
            for (int j = 0; j < x && j < freq.Count; j++)
            {
                xSum += freq[j][0] * freq[j][1];
            }

            ans[i] = xSum;
        }

        return ans;
    }
}