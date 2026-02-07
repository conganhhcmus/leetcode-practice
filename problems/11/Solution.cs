public class Solution
{
    public int MaxArea(int[] height)
    {
        int ans = 0;
        int left = 0, right = height.Length - 1;

        while (left < right)
        {
            int minHeight = Math.Min(height[left], height[right]);
            ans = Math.Max(ans, minHeight * (right - left));

            if (height[left] < height[right])
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return ans;
    }
}