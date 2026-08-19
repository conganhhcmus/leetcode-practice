public class Solution
{
    public int ElevatorRequests(int n, int[] requests)
    {
        int ans = 0;
        int cur = 0;
        foreach (int x in requests)
        {
            ans += Math.Abs(x - cur);
            cur = x;
        }
        return ans;
    }
}
