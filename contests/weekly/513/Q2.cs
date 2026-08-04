public class Solution
{
    public int CountRatioSubarrays(int[] nums, int a, int b)
    {
        int n = nums.Length;
        int[] cntO = new int[n + 1];
        int[] cntE = new int[n + 1];
        for (int i = 0; i < n; i++)
        {
            if (nums[i] % 2 == 0)
            {
                cntE[i + 1] = cntE[i] + 1;
                cntO[i + 1] = cntO[i];
            }
            else
            {
                cntO[i + 1] = cntO[i] + 1;
                cntE[i + 1] = cntE[i];
            }
        }
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                int odd = cntO[j + 1] - cntO[i];
                int even = cntE[j + 1] - cntE[i];
                if (even * b <= odd * a) ans++;
            }
        }
        return ans;
    }
}
