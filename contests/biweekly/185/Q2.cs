public class Solution
{
    public int MinLights(int[] lights)
    {
        int n = lights.Length;
        int[] lines = new int[n + 1];
        for (int i = 0; i < n; i++)
        {
            if (lights[i] > 0)
            {
                int min = Math.Max(0, i - lights[i]);
                int max = Math.Min(n - 1, i + lights[i]);
                lines[min] += 1;
                lines[max + 1] -= 1;
            }
        }
        int ans = 0;
        int cur = 0;
        int cnt = 0;
        for (int i = 0; i < n; i++)
        {
            cur += lines[i];
            if (cur <= 0) cnt++;
            else
            {
                ans += (cnt + 2) / 3;
                cnt = 0;
            }
        }
        ans += (cnt + 2) / 3;
        return ans;
    }
}
