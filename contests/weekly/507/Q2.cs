public class Solution
{
    public int CountValidSubarrays(int[] nums, int x)
    {
        int n = nums.Length;
        long[] pref = new long[n + 1];
        for (int i = 0; i < n; i++) pref[i + 1] = pref[i] + nums[i];
        int cnt = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                long sum = pref[j + 1] - pref[i];
                string str = sum.ToString();
                int first = str[0] - '0';
                int last = str[^1] - '0';
                if (first == x && last == x) cnt++;
            }
        }
        return cnt;
    }
}
