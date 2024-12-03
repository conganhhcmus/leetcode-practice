namespace Problem_2070;

public class Solution
{
    public int[] MaximumBeauty(int[][] items, int[] queries)
    {
        Array.Sort(items, (a, b) => a[0] - b[0]);
        int n = items.Length;
        int[] MaxBeauty = new int[n];
        int max = 0;
        for (int i = 0; i < n; i++)
        {
            max = Math.Max(max, items[i][1]);
            MaxBeauty[i] = max;
        }
        int[] ans = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            int index = FindIndex(items, n, queries[i]);
            if (index != -1)
            {
                ans[i] = MaxBeauty[index];
            }
        }
        return ans;
    }

    private int FindIndex(int[][] items, int n, int price)
    {
        int start = 0;
        int end = n - 1;
        while (start <= end)
        {
            int mid = start + (end - start) / 2;

            if (items[mid][0] > price)
            {
                end = mid - 1;
            }
            else
            {
                start = mid + 1;
            }
        }
        return end;
    }
}