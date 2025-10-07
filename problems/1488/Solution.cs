#if DEBUG
namespace Problems_1488;
#endif

public class Solution
{
    public int[] AvoidFlood(int[] rains)
    {
        int n = rains.Length;
        int[] ans = new int[n];
        Dictionary<int, int> map = [];
        List<int> dry = [];
        for (int i = 0; i < n; i++)
        {
            if (rains[i] == 0)
            {
                ans[i] = 1;
                dry.Add(i);
                continue;
            }

            if (map.TryGetValue(rains[i], out int last))
            {
                int index = BinarySearch(dry, last);
                if (index == -1) return [];
                ans[dry[index]] = rains[i];
                dry.RemoveAt(index);
            }

            map[rains[i]] = i;
            ans[i] = -1;
        }

        return ans;
    }

    int BinarySearch(List<int> arr, int val)
    {
        int l = 0, r = arr.Count - 1;
        int ans = -1;
        while (l <= r)
        {
            int m = l + (r - l) / 2;
            if (arr[m] > val)
            {
                ans = m;
                r = m - 1;
            }
            else
            {
                l = m + 1;
            }
        }

        return ans;
    }
}