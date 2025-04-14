#if DEBUG
namespace Problems_1534;
#endif

public class Solution
{
    public int CountGoodTriplets(int[] arr, int a, int b, int c)
    {
        // brute force
        int n = arr.Length;
        int ret = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                for (int k = j + 1; k < n; k++)
                {
                    if (Math.Abs(arr[i] - arr[j]) <= a && Math.Abs(arr[j] - arr[k]) <= b && Math.Abs(arr[i] - arr[k]) <= c) ret++;
                }
            }
        }
        return ret;
    }
}