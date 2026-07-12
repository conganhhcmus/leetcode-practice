public class Solution
{
    public int[] ArrayRankTransform(int[] arr)
    {
        int n = arr.Length;
        int[] vals = [.. arr.ToHashSet()];
        Array.Sort(vals);
        int[] ans = new int[n];
        for (int i = 0; i < n; i++)
        {
            ans[i] = Array.BinarySearch(vals, arr[i]) + 1;
        }
        return ans;
    }
}
