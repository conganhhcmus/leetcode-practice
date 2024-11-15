namespace Problem_1574;

public class Solution
{
    public static void Execute()
    {
        int[] arr = [58, 68, 54, 45, 52, 21, 33, 35, 54, 22, 58, 13, 67, 31, 25, 66, 27, 75, 57, 81, 30, 44, 22, 45, 34, 21, 8, 11, 82, 60, 37, 35, 3, 44, 31, 80, 40, 74, 1, 2, 47];
        var solution = new Solution();
        Console.WriteLine(solution.FindLengthOfShortestSubarray(arr));
    }
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