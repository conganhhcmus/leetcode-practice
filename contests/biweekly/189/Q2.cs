public class Solution
{
    public int MinOperations(string s)
    {
        int n = s.Length;
        // move first, make same
        int ans = int.MaxValue;
        // choose the middle
        char[] arr = new char[2 * n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = s[i];
            arr[i + n] = s[i];
        }

        for (int i = 0; i < n; i++)
        {
            int cnt = i;
            for (int j = 0; j < n / 2; j++)
            {
                int diff = Math.Abs(arr[i + j] - arr[i + n - j - 1]);
                cnt += Math.Min(diff, 26 - diff);
            }
            ans = Math.Min(ans, cnt);
        }

        return ans;
    }
}
