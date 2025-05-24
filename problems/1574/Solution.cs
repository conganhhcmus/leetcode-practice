#if DEBUG
namespace Problems_1574;
#endif

public class Solution
{
    public int FindLengthOfShortestSubarray(int[] arr)
    {
        int n = arr.Length;
        int left = 0, right = n - 1;
        while (left + 1 < n && arr[left] <= arr[left + 1]) left++;
        while (right > 0 && arr[right] >= arr[right - 1]) right--;
        if (left >= right) return 0;
        int ret = Math.Min(n - (left + 1), right);
        for (int i = 0; i <= left; i++)
        {
            int target = arr[i];
            int low = right, high = n - 1, ans = n;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (arr[mid] >= target)
                {
                    ans = mid;
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            ret = Math.Min(ret, ans - i - 1);
        }
        return ret;
    }
}