public class Solution
{
    public int LongestAlternating(int[] nums)
    {
        int n = nums.Length;
        int[] up = new int[n];
        int[] down = new int[n];
        int[] rUp = new int[n];
        int[] rDown = new int[n];
        Array.Fill(up, 1);
        Array.Fill(down, 1);
        Array.Fill(rUp, 1);
        Array.Fill(rDown, 1);
        int ans = 1;
        for (int i = 1; i < n; i++)
        {
            if (nums[i] > nums[i - 1])
            {
                up[i] = down[i - 1] + 1;
            }
            else if (nums[i] < nums[i - 1])
            {
                down[i] = up[i - 1] + 1;
            }
            ans = Math.Max(ans, Math.Max(up[i], down[i]));
        }

        for (int i = n - 2; i >= 0; i--)
        {
            if (nums[i] < nums[i + 1])
            {
                rUp[i] = rDown[i + 1] + 1;
            }
            else if (nums[i] > nums[i + 1])
            {
                rDown[i] = rUp[i + 1] + 1;
            }
            ans = Math.Max(ans, Math.Max(rUp[i], rDown[i]));
        }

        for (int i = 1; i < n - 1; i++)
        {
            // remove element at i
            if (nums[i - 1] < nums[i + 1])
            {
                ans = Math.Max(ans, down[i - 1] + rDown[i + 1]);
            }
            else if (nums[i - 1] > nums[i + 1])
            {
                ans = Math.Max(ans, up[i - 1] + rUp[i + 1]);
            }
        }

        return ans;
    }
}