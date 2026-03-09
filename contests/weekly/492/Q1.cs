public class Solution
{
    public int MinimumIndex(int[] capacity, int itemSize)
    {
        int ans = -1;
        int n = capacity.Length;
        for (int i = 0; i < n; i++)
        {
            if (capacity[i] >= itemSize)
            {
                if (ans == -1 || capacity[ans] > capacity[i]) ans = i;
            }
        }
        return ans;
    }
}