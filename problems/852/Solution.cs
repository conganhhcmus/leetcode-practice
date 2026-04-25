public class Solution
{
    public int PeakIndexInMountainArray(int[] arr)
    {
        int n = arr.Length;
        int low = 1, high = n - 1, ans = 0;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (arr[mid] >= arr[mid - 1])
            {
                ans = mid;
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return ans;
    }
}
