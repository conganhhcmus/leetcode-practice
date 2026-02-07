public class Solution
{
    public int CountSubarrays(int[] a)
    {
        int n = a.Length;
        int ret = 0;
        for (int i = 0; i < n - 2; i++)
        {
            if (2 * (a[i] + a[i + 2]) == a[i + 1]) ret++;
        }
        return ret;
    }
}