public class Solution
{
    public int LongestArithmetic(int[] nums)
    {
        int n = nums.Length;
        int m = n - 1;
        int[] D = new int[m];
        for (int i = 0; i < m; i++)
        {
            D[i] = nums[i] - nums[i + 1];
        }
        int[] L = new int[m];
        L[0] = 1;
        for (int i = 1; i < m; i++)
        {
            if (D[i] == D[i - 1])
            {
                L[i] = L[i - 1] + 1;
            }
            else
            {
                L[i] = 1;
            }
        }

        int[] R = new int[m];
        R[m - 1] = 1;
        for (int i = m - 2; i >= 0; i--)
        {
            if (D[i] == D[i + 1])
            {
                R[i] = R[i + 1] + 1;
            }
            else
            {
                R[i] = 1;
            }
        }

        int ans = 0;
        for (int i = 0; i < m; i++)
        {
            ans = Math.Max(ans, R[i]);
            ans = Math.Max(ans, L[i]);
        }

        if (ans < m) ans++;

        for (int i = 1; i < m; i++)
        {
            // change at i
            int sum = D[i] + D[i - 1];
            if (sum % 2 == 0)
            {
                int d = sum / 2;
                int len = 2;
                if (i - 2 >= 0 && D[i - 2] == d)
                {
                    len += L[i - 2];
                }
                if (i + 1 < m && D[i + 1] == d)
                {
                    len += R[i + 1];
                }
                ans = Math.Max(ans, len);
            }
        }

        return ans + 1;
    }
}