public class Solution
{
    public int LargestOverlap(int[][] img1, int[][] img2)
    {
        int n = img1.Length;
        List<(int x, int y)> arr1 = [];
        List<(int x, int y)> arr2 = [];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (img1[i][j] == 1) arr1.Add((i, j));
                if (img2[i][j] == 1) arr2.Add((i, j));
            }
        }
        int ans = 0;
        Dictionary<int, int> map = [];
        foreach (var p1 in arr1)
        {
            foreach (var p2 in arr2)
            {
                int dx = p1.x - p2.x;
                int dy = p1.y - p2.y;
                int key = dx * 100 + dy;
                map[key] = map.GetValueOrDefault(key, 0) + 1;
                ans = Math.Max(ans, map[key]);
            }
        }
        return ans;
    }
}