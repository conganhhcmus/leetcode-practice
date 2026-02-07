public class Solution
{
    public int[] AssignElements(int[] groups, int[] elements)
    {
        int n = groups.Length, m = elements.Length;
        int[] ans = new int[n];
        int[] hits = new int[100001];
        Array.Fill(hits, -1);
        for (int i = 0; i < m; i++)
        {
            int v = elements[i];
            if (hits[v] == -1)
            {
                for (int j = v; j < 100001; j += v)
                {
                    if (hits[j] == -1) hits[j] = i;
                }
            }
        }
        for (int i = 0; i < n; i++)
        {
            ans[i] = hits[groups[i]];
        }

        return ans;
    }
}