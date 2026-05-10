public class Solution
{
    public long MinArraySum(int[] nums)
    {
        int n = nums.Length;
        Array.Sort(nums);
        Dictionary<int, int> map = [];
        int max = 0;
        for (int i = 0; i < n; i++)
        {
            int x = nums[i];
            if (!map.ContainsKey(x)) map[x] = 0;
            map[x]++;
            if (max < x) max = x;
        }
        long sum = 0;
        for (int i = 0; i < n; i++)
        {
            int x = nums[i];
            if (!map.ContainsKey(x)) continue;
            for (int y = 2 * x; y <= max; y += x)
            {
                if (map.TryGetValue(y, out int value))
                {
                    map[x] += value;
                    map.Remove(y);
                }
            }
            sum += 1L * x * map[x];
            map.Remove(x);
        }

        return sum;
    }
}
