#if DEBUG
namespace Problems_303;
#endif

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


public class Solution
{
    public List<dynamic> Execute(string[] actions, dynamic values)
    {
        List<dynamic> result = [];
        object[] objectList = JsonConvert.DeserializeObject<object[]>(values);
        NumArray numArr = null;
        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "NumArray":
                    numArr = new NumArray(CastType<int[]>(objectList[i])[0]);
                    result.Add(null);
                    break;
                case "sumRange":
                    result.Add(numArr.SumRange(CastType<int>(objectList[i])[0], CastType<int>(objectList[i])[1]));
                    break;
                default:
                    break;
            }
        }
        return result;
    }

    private T[] CastType<T>(object value)
    {
        return JsonConvert.DeserializeObject<T[]>(JsonConvert.SerializeObject(value));
    }
}