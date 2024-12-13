#if DEBUG
namespace Problems_2593;
#endif

public class Solution
{
    public long FindScore(int[] nums)
    {
        int n = nums.Length;
        long ans = 0;
        bool[] visited = new bool[n];
        int[][] arr = new int[n][];
        for (int i = 0; i < n; i++)
        {
            arr[i] = [nums[i], i];
        }

        Array.Sort(arr, (a, b) =>
        {
            if (a[0] == b[0]) return a[1] - b[1];
            return a[0] - b[0];
        });

        for (int i = 0; i < n; i++)
        {
            int val = arr[i][0];
            int idx = arr[i][1];
            if (!visited[idx])
            {
                visited[idx] = true;
                if (idx + 1 < n) visited[idx + 1] = true;
                if (idx - 1 >= 0) visited[idx - 1] = true;
                ans += val;
            }
        }
        return ans;
    }
}