public class Solution
{
    public int ClosestTarget(string[] words, string target, int startIndex)
    {
        int ans = int.MaxValue;
        int n = words.Length;
        for (int i = 0; i < n; i++)
        {
            if (words[i] == target)
            {
                ans = Math.Min(ans, Math.Abs(startIndex - i));
                ans = Math.Min(ans, n - Math.Abs(startIndex - i));
            }
        }

        return ans == int.MaxValue ? -1 : ans;
    }
}
