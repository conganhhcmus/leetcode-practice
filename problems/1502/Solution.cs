public class Solution
{
    public bool CanMakeArithmeticProgression(int[] arr)
    {
        int n = arr.Length;
        Array.Sort(arr);
        int diff = arr[1] - arr[0];
        for (int i = 1; i < n; i++)
        {
            if (arr[i] - arr[i - 1] != diff) return false;
        }
        return true;
    }
}