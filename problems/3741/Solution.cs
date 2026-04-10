public class Solution
{
    public int MinimumDistance(int[] nums)
    {
        int n = nums.Length;
        int[] indexs = new int[n];
        for (int i = 0; i < n; i++)
        {
            indexs[i] = i;
        }
        Array.Sort(indexs, (a, b) =>
        {
            if (nums[a] == nums[b]) return a - b;
            return nums[a] - nums[b];
        });

        int ans = n + 1;
        int count = 1;
        List<int> candidate = [indexs[0]];
        for (int i = 1; i < n; i++)
        {
            if (nums[indexs[i]] == nums[indexs[i - 1]])
            {
                count++;
                candidate.Add(indexs[i]);
                if (count >= 3)
                {
                    ans = Math.Min(ans, candidate[count - 1] - candidate[count - 3]);
                }
            }
            else
            {
                count = 1;
                candidate = [indexs[i]];
            }
        }

        return ans == n + 1 ? -1 : 2 * ans;
    }
}