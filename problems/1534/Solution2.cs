#if DEBUG
namespace Problems_1534_2;
#endif

public class Solution
{
    public int CountGoodTriplets(int[] arr, int a, int b, int c)
    {
        int n = arr.Length;
        int ret = 0;
        int[] sum = new int[1001];
        for (int j = 0; j < n; ++j)
        {
            for (int k = j + 1; k < n; ++k)
            {
                if (Math.Abs(arr[j] - arr[k]) <= b)
                {
                    int lj = arr[j] - a, rj = arr[j] + a;
                    int lk = arr[k] - c, rk = arr[k] + c;
                    int l = Math.Max(0, Math.Max(lj, lk));
                    int r = Math.Min(1000, Math.Min(rj, rk));
                    if (l <= r)
                    {
                        if (l == 0) ret += sum[r];
                        else ret += sum[r] - sum[l - 1];
                    }
                }
            }

            for (int i = arr[j]; i <= 1000; ++i)
            {
                ++sum[i];
            }
        }
        return ret;
    }
}