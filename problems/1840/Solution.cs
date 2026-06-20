public class Solution
{
    public int MaxBuilding(int n, int[][] restrictions)
    {
        List<int[]> arr = [.. restrictions];
        arr.Add([1, 0]);
        arr.Add([n, int.MaxValue]);
        arr.Sort((a, b) => a[0] - b[0]);
        int m = arr.Count;
        int[] diff = new int[m];
        // diff[i] = abs(h[i] - h[i-1])
        int[] height = new int[m];
        Array.Fill(height, int.MaxValue);
        for (int i = 0; i < m; i++)
        {
            if (i > 0) diff[i] = arr[i][0] - arr[i - 1][0];
            height[i] = Math.Min(height[i], arr[i][1]);
        }
        for (int i = 1; i < m; i++)
        {
            height[i] = Math.Min(height[i - 1] + diff[i], height[i]);
        }
        for (int i = m - 2; i >= 0; i--)
        {
            height[i] = Math.Min(height[i + 1] + diff[i + 1], height[i]);
        }
        int ans = 0;
        for (int i = 1; i < m; i++)
        {
            int val = (height[i - 1] + height[i] + diff[i]) / 2;
            if (ans < val) ans = val;
        }
        return ans;
    }
}
