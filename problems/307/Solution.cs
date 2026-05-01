public class NumArray
{
    int n;
    int[] tree;
    public NumArray(int[] nums)
    {
        n = nums.Length;
        tree = new int[4 * n];
        Build(0, n - 1, 1, nums);
    }

    void Build(int st, int ed, int node, int[] nums)
    {
        if (st == ed)
        {
            tree[node] = nums[st];
            return;
        }
        int mi = st + (ed - st) / 2;
        Build(st, mi, 2 * node, nums);
        Build(mi + 1, ed, 2 * node + 1, nums);
        tree[node] = tree[2 * node] + tree[2 * node + 1];
    }

    void Update(int st, int ed, int node, int idx, int val)
    {
        if (st == ed)
        {
            tree[node] = val;
            return;
        }
        int mi = st + (ed - st) / 2;
        if (idx <= mi)
        {
            Update(st, mi, 2 * node, idx, val);
        }
        else
        {
            Update(mi + 1, ed, 2 * node + 1, idx, val);
        }
        tree[node] = tree[2 * node] + tree[2 * node + 1];
    }

    int Query(int st, int ed, int node, int l, int r)
    {
        if (l > ed || r < st) return 0;
        if (l <= st && r >= ed) return tree[node];
        int mi = st + (ed - st) / 2;
        return Query(st, mi, 2 * node, l, r) + Query(mi + 1, ed, 2 * node + 1, l, r);
    }

    public void Update(int index, int val)
    {
        Update(0, n - 1, 1, index, val);
    }

    public int SumRange(int left, int right)
    {
        return Query(0, n - 1, 1, left, right);
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * obj.Update(index,val);
 * int param_2 = obj.SumRange(left,right);
 */

#if DEBUG
public class Solution
{
    public List<dynamic> Execute(string[] actions, object[] values)
    {
        List<dynamic> result = [];
        NumArray numArr = null;

        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "NumArray":
                    int[] data = CastType<int[][]>(values[i])[0];
                    numArr = new NumArray(data);
                    result.Add(null);
                    break;
                case "update":
                    int[] update = CastType<int[]>(values[i]);
                    numArr.Update(update[0], update[1]);
                    result.Add(null);
                    break;
                case "sumRange":
                    int[] range = CastType<int[]>(values[i]);
                    result.Add(numArr.SumRange(range[0], range[1]));
                    break;
            }
        }
        return result;
    }

    private static T CastType<T>(object value) => ((JsonElement)value).Deserialize<T>(Program.JsonOptions);
}
#endif
