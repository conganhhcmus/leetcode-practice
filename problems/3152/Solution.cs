#if DEBUG
namespace Problems_3152;
#endif

public class Solution
{
    public bool[] IsArraySpecial(int[] nums, int[][] queries)
    {
        int n = nums.Length;
        int[] prefix = new int[n];
        prefix[0] = 0;
        for (int i = 1; i < n; ++i)
        {
            if ((nums[i] & 1) == (nums[i - 1] & 1))
            {
                prefix[i] = prefix[i - 1] + 1;
            }
            else
            {
                prefix[i] = prefix[i - 1];
            }
        }

        bool[] ans = new bool[queries.Length];
        for (var i = 0; i < queries.Length; ++i)
        {
            ans[i] = (prefix[queries[i][0]] - prefix[queries[i][1]]) == 0;
        }
        return ans;
    }

    // public bool[] IsArraySpecial(int[] nums, int[][] queries)
    // {
    //     List<int[]> map = [];
    //     int n = nums.Length;
    //     int start = 0;
    //     for (int i = 1; i < n; i++)
    //     {
    //         if ((nums[i] & 1) == (nums[i - 1] & 1))
    //         {
    //             if (start < i - 1)
    //             {
    //                 map.Add([start, i - 1]);
    //             }
    //             start = i;
    //         }
    //     }
    //     if (start < n - 1)
    //     {
    //         map.Add([start, n - 1]);
    //     }

    //     bool[] ans = new bool[queries.Length];
    //     for (int i = 0; i < queries.Length; i++)
    //     {
    //         ans[i] = IsSpecial(map, queries[i][0], queries[i][1]);
    //     }

    //     return ans;
    // }

    // private bool IsSpecial(List<int[]> map, int st, int ed)
    // {
    //     if (st == ed) return true;
    //     int left = 0;
    //     int right = map.Count;
    //     while (left < right)
    //     {
    //         int mid = left + (right - left) / 2;
    //         if (map[mid][0] <= st && map[mid][1] >= ed)
    //         {
    //             return true;
    //         }

    //         if (map[mid][0] > st)
    //         {
    //             right = mid;
    //         }
    //         else
    //         {
    //             left = mid + 1;
    //         }
    //     }

    //     return false;
    // }
}