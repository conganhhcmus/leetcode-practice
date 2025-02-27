#if DEBUG
namespace Problems_873_2;
#endif

public class Solution
{
    public int LenLongestFibSubseq(int[] arr)
    {
        int ans = 0;
        int n = arr.Length;
        Dictionary<int, int> map = [];
        for (int i = 0; i < n; i++) map[arr[i]] = i;

        for (int start = 0; start < n; start++)
        {
            for (int next = start + 1; next < n; next++)
            {
                int prev = arr[next];
                int curr = arr[start] + arr[next];
                int len = 2;
                while (map.ContainsKey(curr))
                {
                    int tmp = curr;
                    curr += prev;
                    prev = tmp;
                    len++;
                    ans = Math.Max(ans, len);
                }
            }
        }

        return ans;
    }
}