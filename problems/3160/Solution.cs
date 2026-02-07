public class Solution
{
    public int[] QueryResults(int limit, int[][] queries)
    {
        Dictionary<int, int> prevColor = [];
        Dictionary<int, int> map = [];
        int n = queries.Length;
        int[] ans = new int[n];
        for (int i = 0; i < n; i++)
        {
            int oldColor = prevColor.GetValueOrDefault(queries[i][0], -1);
            int newColor = queries[i][1];
            if (oldColor >= 0 && map.TryGetValue(oldColor, out int value))
            {
                map[oldColor] = --value;
                if (value == 0)
                {
                    map.Remove(oldColor);
                }
            }
            map[newColor] = map.GetValueOrDefault(newColor, 0) + 1;
            prevColor[queries[i][0]] = newColor;
            ans[i] = map.Count;
        }
        return ans;
    }
}