public class Solution
{
    public IList<IList<int>> MinimumAbsDifference(int[] arr)
    {
        int n = arr.Length;
        Array.Sort(arr);
        IList<IList<int>> ret = [];
        int min = int.MaxValue;
        for (int i = 1; i < n; i++)
        {
            min = Math.Min(min, arr[i] - arr[i - 1]);
        }
        for (int i = 1; i < n; i++)
        {
            if (arr[i] - arr[i - 1] == min)
            {
                ret.Add([arr[i - 1], arr[i]]);
            }
        }
        return ret;
    }
}