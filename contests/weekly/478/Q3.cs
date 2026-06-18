public class Solution
{
    public int MinMirrorPairDistance(int[] nums)
    {
        int n = nums.Length;
        int ans = int.MaxValue;
        Dictionary<int, int> last = [];
        for (int i = 0; i < n; i++)
        {
            if (last.TryGetValue(nums[i], out int j))
            {
                ans = Math.Min(ans, Math.Abs(i - j));
            }
            last[Rev(nums[i])] = i;
        }
        return ans == int.MaxValue ? -1 : ans;

        int Rev(int n)
        {
            int a = 0;
            while (n > 0)
            {
                a = a * 10 + n % 10;
                n /= 10;
            }
            return a;
        }
    }
}
