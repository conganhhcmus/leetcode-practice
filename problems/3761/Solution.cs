public class Solution
{
    public int MinMirrorPairDistance(int[] nums)
    {
        int n = nums.Length;
        int[] next = new int[n];
        Dictionary<int, int> map = [];

        int Reverse(int n)
        {
            int r = 0;
            while (n > 0)
            {
                r = r * 10 + n % 10;
                n /= 10;
            }

            return r;
        }

        for (int i = n - 1; i >= 0; i--)
        {
            int val = Reverse(nums[i]);
            next[i] = map.GetValueOrDefault(val, -1);
            map[nums[i]] = i;
        }
        int ans = int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            int j = next[i];
            if (j == -1)
                continue;
            ans = Math.Min(ans, j - i);
        }
        return ans == int.MaxValue ? -1 : ans;
    }
}
