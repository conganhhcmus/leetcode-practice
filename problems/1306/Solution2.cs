public class Solution
{
    public bool CanReach(int[] arr, int start)
    {
        int n = arr.Length;
        bool[] vis = new bool[n];
        return Check(start);
        bool Check(int x)
        {
            if (x < 0 || x >= n || vis[x]) return false;
            if (arr[x] == 0) return true;
            vis[x] = true;
            return Check(x - arr[x]) || Check(x + arr[x]);
        }
    }
}
