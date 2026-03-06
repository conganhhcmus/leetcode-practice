public class Solution
{
    public int[] ColorTheArray(int n, int[][] queries)
    {
        int m = queries.Length;
        int[] ans = new int[m];
        int cnt = 0;
        int[] colors = new int[n];
        for (int i = 0; i < m; i++)
        {
            int index = queries[i][0], color = queries[i][1];
            if (index - 1 >= 0 && colors[index - 1] != 0)
            {
                if (colors[index - 1] == colors[index]) cnt--;
                if (colors[index - 1] == color) cnt++;
            }
            if (index + 1 < n && colors[index + 1] != 0)
            {
                if (colors[index + 1] == colors[index]) cnt--;
                if (colors[index + 1] == color) cnt++;
            }
            colors[index] = color;
            ans[i] = cnt;
        }

        return ans;
    }
}