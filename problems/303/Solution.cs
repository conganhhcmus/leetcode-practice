public class NumArray
{
    long[] sum;
    public NumArray(int[] nums)
    {
        int n = nums.Length;
        sum = new long[n + 1];
        for (int i = 0; i < n; ++i)
        {
            sum[i + 1] = sum[i] + nums[i];
        }
    }

    public int SumRange(int left, int right)
    {
        long ret = sum[right + 1] - sum[left];
        return (int)ret;
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(left,right);
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
                    numArr = new NumArray(CastType<int[][]>(values[i])[0]);
                    result.Add(null);
                    break;
                case "sumRange":
                    int[] rangeArgs = CastType<int[]>(values[i]);
                    result.Add(numArr.SumRange(rangeArgs[0], rangeArgs[1]));
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
