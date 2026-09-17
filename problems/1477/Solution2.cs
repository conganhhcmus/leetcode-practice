public class Solution
{
    public int MinSumOfLengths(int[] arr, int target)
    {
        int n = arr.Length;
        Dictionary<int, int> map = [];
        map[0] = -1;
        int minL = n;
        int ans = n + 1;
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += arr[i];
            if (map.TryGetValue(sum - target, out int j))
            {
                int len = i - j;
                ans = Math.Min(ans, len + (j == -1 ? n : arr[j]));
                minL = Math.Min(minL, len);
            }
            arr[i] = minL;
            map[sum] = i;
        }
        return ans > n ? -1 : ans;
    }
}