public class MajorityChecker
{
    int n;
    Pair[] segTree;
    Dictionary<int, List<int>> valToIndex;
    public MajorityChecker(int[] arr)
    {
        n = arr.Length;
        valToIndex = [];
        for (int i = 0; i < n; i++)
        {
            valToIndex.TryAdd(arr[i], []);
            valToIndex[arr[i]].Add(i);
        }
        segTree = new Pair[4 * n];
        Build(arr, 1, 0, n - 1);
    }

    void Build(int[] arr, int node, int start, int end)
    {
        if (start == end)
        {
            segTree[node] = new(arr[start], 1);
            return;
        }
        int mid = start + (end - start) / 2;
        Build(arr, 2 * node, start, mid);
        Build(arr, 2 * node + 1, mid + 1, end);
        segTree[node] = Merge(segTree[2 * node], segTree[2 * node + 1]);
    }

    Pair Merge(Pair left, Pair right)
    {
        if (left.Value == right.Value)
        {
            return new(left.Value, left.Occurrence + right.Occurrence);
        }
        if (left.Occurrence > right.Occurrence)
        {
            return new(left.Value, left.Occurrence - right.Occurrence);
        }
        if (left.Occurrence < right.Occurrence)
        {
            return new(right.Value, right.Occurrence - left.Occurrence);
        }

        return new(left.Value, 0);
    }

    Pair Query(int node, int start, int end, int left, int right)
    {
        if (left > end || right < start) return new(0, 0);
        if (left <= start && right >= end) return segTree[node];
        int mid = start + (end - start) / 2;
        Pair leftVal = Query(2 * node, start, mid, left, right);
        Pair rightVal = Query(2 * node + 1, mid + 1, end, left, right);
        return Merge(leftVal, rightVal);
    }

    public int Query(int left, int right, int threshold)
    {
        Pair ret = Query(1, 0, n - 1, left, right);
        List<int> indices = valToIndex.GetValueOrDefault(ret.Value, []);
        if (indices.Count == 0) return -1;
        int l = LowerBound(indices, left);
        int r = UpperBound(indices, right);
        int freq = r - l;
        return (freq >= threshold) ? ret.Value : -1;
    }

    int LowerBound(List<int> list, int target)
    {
        int low = 0, high = list.Count - 1, ret = list.Count;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (list[mid] >= target)
            {
                ret = mid;
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }
        return ret;
    }

    int UpperBound(List<int> list, int target)
    {
        int low = 0, high = list.Count - 1, ret = list.Count;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (list[mid] > target)
            {
                ret = mid;
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }
        return ret;
    }
}

public record Pair(int Value, int Occurrence);
/**
 * Your MajorityChecker object will be instantiated and called as such:
 * MajorityChecker obj = new MajorityChecker(arr);
 * int param_1 = obj.Query(left,right,threshold);
 */

#if DEBUG
public class Solution
{
    public List<dynamic> Execute(string[] actions, object[] values)
    {
        List<dynamic> result = [];
        MajorityChecker majorityChecker = null;
        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "MajorityChecker":
                    majorityChecker = new MajorityChecker(CastType<int[][]>(values[i])[0]);
                    result.Add(null);
                    break;
                case "query":
                    int[] queryArgs = CastType<int[]>(values[i]);
                    result.Add(majorityChecker.Query(queryArgs[0], queryArgs[1], queryArgs[2]));
                    break;
                default:
                    break;
            }
        }
        return result;
    }

    private static T CastType<T>(object value) => ((JsonElement)value).Deserialize<T>(Program.JsonOptions);
}
#endif
