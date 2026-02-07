public class Solution
{
    public int MinimumBoxes(int[] apple, int[] capacity)
    {
        int sum = 0;
        foreach (int num in apple)
        {
            sum += num;
        }
        Array.Sort(capacity);
        int ans = 0;
        for (int i = capacity.Length - 1; i >= 0; i--)
        {
            if (sum <= 0) break;
            ans++;
            sum -= capacity[i];
        }

        return ans;
    }
}