public class Solution
{
    public int MaximumAND(int[] nums, int k, int m)
    {
        int ans = 0;
        int n = nums.Length;
        for (int i = 30; i >= 0; i--)
        {
            int val = ans | (1 << i);
            int[] need = new int[n];
            for (int j = 0; j < n; j++)
            {
                need[j] = Cost(nums[j], val);
            }

            Array.Sort(need);
            long sum = 0;
            for (int j = 0; j < m; j++)
            {
                sum += need[j];
            }

            if (sum <= k)
            {
                ans = val;
            }
        }
        return ans;
    }

    int Cost(int n, int t)
    {
        int cur = n;
        for (int i = 30; i >= 0; i--)
        {
            int bit = 1 << i;
            if ((t & bit) != 0 && (cur & bit) == 0)
            {
                cur = ((cur >> i) | 1) << i;
            }
        }
        return cur - n;
    }
}