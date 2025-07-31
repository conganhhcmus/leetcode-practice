#if DEBUG
namespace Problems_898;
#endif

public class Solution
{
    public int SubarrayBitwiseORs(int[] arr)
    {
        int n = arr.Length;
        HashSet<int> ans = [];
        HashSet<int> curr = [];
        for (int i = 0; i < n; i++)
        {
            if (i != 0 && arr[i] == arr[i - 1]) continue;
            HashSet<int> next = [];
            foreach (int val in curr)
            {
                next.Add(val | arr[i]);
            }
            next.Add(arr[i]);
            foreach (int val in next)
            {
                ans.Add(val);
            }
            curr = next;
        }
        return ans.Count;
    }
}