namespace Problem_1574;

public class Solution
{
    public int FindLengthOfShortestSubarray(int[] arr)
    {
        int i = 0;
        int j = arr.Length - 1;
        while (i + 1 < arr.Length && arr[i] < arr[i + 1])
        {
            i++;
        }
        if (i == arr.Length - 1) return 0;
        while (j - 1 >= i && arr[j] >= arr[j - 1])
        {
            j--;
        }
        int min = arr.Length - 1 - i;
        int left = 0;
        int right = j;
        while (right < arr.Length)
        {
            while (left <= i && arr[left] <= arr[right])
            {
                left++;
            }
            min = Math.Min(min, right - left);
            right++;
        }

        return min;
    }
}