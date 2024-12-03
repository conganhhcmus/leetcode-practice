namespace Problem_1331;

public class Solution
{
    public int[] ArrayRankTransform(int[] arr)
    {
        int[] ans = new int[arr.Length];
        int[] tmp = [.. arr.ToHashSet()];
        Array.Sort(tmp);

        for (int i = 0; i < ans.Length; i++)
        {
            int rank = Array.IndexOf(tmp, arr[i]);
            ans[i] = rank + 1;
        }
        return ans;
    }
}