public class Solution
{
    public int MinMirrorPairDistance(int[] nums)
    {
        int n = nums.Length;
        Dictionary<int, int> map = [];

        int ans = n + 1;
        for (int i = n - 1; i >= 0; i--)
        {
            int val = Reverse(nums[i]);
            if (map.TryGetValue(val, out int j))
            {
                ans = Math.Min(ans, j - i);
            }
            map[nums[i]] = i;
        }

        return ans == n + 1 ? -1 : ans;
    }

    int Reverse(int x)
    {
        int y = 0;
        while (x > 0)
        {
            y = y * 10 + x % 10;
            x /= 10;
        }
        return y;
    }
}
