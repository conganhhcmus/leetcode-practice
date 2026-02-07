public class Solution
{
    public int Trap(int[] height)
    {
        int n = height.Length;
        int ans = 0;
        int left = 0, right = n - 1;
        int maxLeft = 0, maxRight = 0;
        // ans[i] = max(min(maxLeft[i], maxRight[i])-height[i], 0);
        while (left <= right)
        {
            if (height[left] <= height[right])
            {
                if (height[left] >= maxLeft)
                {
                    maxLeft = height[left];
                }
                else
                {
                    ans += maxLeft - height[left];
                }
                left++;
            }
            else
            {
                if (height[right] >= maxRight)
                {
                    maxRight = height[right];
                }
                else
                {
                    ans += maxRight - height[right];
                }
                right--;
            }
        }
        return ans;
    }
}