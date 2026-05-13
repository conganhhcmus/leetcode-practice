public class Solution
{
    public int MinMoves(int[] nums, int limit)
    {
        int n = nums.Length;
        int m = n / 2;
        int[] minArr = new int[m];
        int[] maxArr = new int[m];
        Dictionary<int, int> count = [];
        for (int i = 0; i < m; i++)
        {
            int a = Math.Min(nums[i], nums[n - 1 - i]);
            int b = Math.Max(nums[i], nums[n - 1 - i]);
            minArr[i] = a;
            maxArr[i] = b;
            count[a + b] = count.GetValueOrDefault(a + b, 0) + 1;
        }
        Array.Sort(minArr);
        Array.Sort(maxArr);
        int ans = n;
        for (int c = 2; c <= 2 * limit; c++)
        {
            // count(a > c - 1) = count(a >= c) = m - LowerBound(c)
            // count(b < c - limit) = LowerBound(c - limit)
            int addLeft = m - LowerBound(minArr, c);
            int addRight = LowerBound(maxArr, c - limit);
            int curr = m + addLeft + addRight - count.GetValueOrDefault(c, 0);
            if (ans > curr) ans = curr;
        }
        return ans;
    }

    int LowerBound(int[] arr, int t)
    {
        int low = 0, high = arr.Length - 1, ans = arr.Length;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (arr[mid] >= t)
            {
                ans = mid;
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }
        return ans;
    }
}
