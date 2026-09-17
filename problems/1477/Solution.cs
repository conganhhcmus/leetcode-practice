public class Solution
{
    public int MinSumOfLengths(int[] arr, int target)
    {
        int n = arr.Length;
        int ans = n + 1;
        int[] suff = new int[n + 1];
        Array.Fill(suff, n + 1);
        int sum = 0;
        Dictionary<int, int> map = [];
        map[0] = n;
        for (int i = n - 1; i >= 0; i--)
        {
            sum += arr[i];
            int need = sum - target;
            if (map.TryGetValue(need, out int j))
            {
                suff[i] = Math.Min(suff[i], j - i);
            }
            map[sum] = i;
        }
        map.Clear();
        sum = 0;
        map[0] = 0;
        int min = n + 1;
        for (int mid = 0; mid < n; mid++)
        {
            sum += arr[mid];
            int need = sum - target;
            if (map.TryGetValue(need, out int j))
            {
                min = Math.Min(min, mid - j + 1);
            }
            ans = Math.Min(ans, min + suff[mid + 1]);
            map[sum] = mid + 1;
        }
        if (ans > n) return -1;
        return ans;
    }
}