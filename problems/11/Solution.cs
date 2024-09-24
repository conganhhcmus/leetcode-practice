namespace Practice_11;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        int[] height = [1, 8, 6, 2, 5, 4, 8, 3, 7];
        Console.WriteLine(solution.MaxArea(height));
    }
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