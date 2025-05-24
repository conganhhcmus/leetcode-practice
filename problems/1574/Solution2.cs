#if DEBUG
namespace Problems_1574_2;
#endif

public class Solution
{
    public int FindLengthOfShortestSubarray(int[] arr)
    {
        int n = arr.Length;
        int left = 0, right = n - 1;
        while (right > 0 && arr[right] >= arr[right - 1]) right--;
        int ret = right - left;
        while (left < right && (left == 0 || arr[left] >= arr[left - 1]))
        {
            while (right < n && arr[left] > arr[right]) right++;
            ret = Math.Min(ret, right - left - 1);
            left++;
        }
        return ret;
    }
}