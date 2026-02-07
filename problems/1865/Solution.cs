public class FindSumPairs
{
    readonly Dictionary<int, int> dict1 = [];
    readonly Dictionary<int, int> dict2 = [];
    readonly int[] data = null;

    public FindSumPairs(int[] nums1, int[] nums2)
    {
        foreach (int num in nums1)
        {
            dict1[num] = dict1.GetValueOrDefault(num, 0) + 1;
        }

        foreach (int num in nums2)
        {
            dict2[num] = dict2.GetValueOrDefault(num, 0) + 1;
        }

        data = nums2;
    }

    public void Add(int index, int val)
    {
        dict2[data[index]]--;
        data[index] += val;
        dict2[data[index]] = dict2.GetValueOrDefault(data[index], 0) + 1;
    }

    public int Count(int tot)
    {
        int ans = 0;
        foreach (var pair in dict1)
        {
            ans += pair.Value * dict2.GetValueOrDefault(tot - pair.Key, 0);
        }
        return ans;
    }
}

/**
 * Your FindSumPairs object will be instantiated and called as such:
 * FindSumPairs obj = new FindSumPairs(nums1, nums2);
 * obj.Add(index,val);
 * int param_2 = obj.Count(tot);
 */


public class Solution
{
    public List<dynamic> Execute(string[] actions, dynamic values)
    {
        List<dynamic> result = [];
        FindSumPairs findSumPairs = null;
        object[] objectList = JsonConvert.DeserializeObject<object[]>(values);

        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "FindSumPairs":
                    int[][] data = CastType<int[][]>(objectList[i]);
                    findSumPairs = new FindSumPairs(data[0], data[1]);
                    result.Add(null);
                    break;
                case "add":
                    int[] val = CastType<int[]>(objectList[i]);
                    findSumPairs.Add(val[0], val[1]);
                    result.Add(null);
                    break;
                case "count":
                    result.Add(findSumPairs.Count(CastType<int[]>(objectList[i])[0]));
                    break;
                default:
                    break;
            }
        }
        return result;
    }

    private T CastType<T>(object value)
    {
        return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(value));
    }
}