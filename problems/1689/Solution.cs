public class Solution
{
    public int MinPartitions(string n)
    {
        int ans = 0;
        for (int i = 0; i < n.Length; i++)
        {
            int num = Math.Max(0, n[i] - '0' - ans);
            ans += num;
        }

        return ans;
    }
}