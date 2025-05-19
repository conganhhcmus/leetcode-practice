#if DEBUG
namespace Problems_229;
#endif

public class Solution
{
    public IList<int> MajorityElement(int[] nums)
    {
        int n = nums.Length;
        int target = n / 3;
        HashSet<int> ret = [];
        Dictionary<int, int> count = [];
        foreach (int num in nums)
        {
            count[num] = count.GetValueOrDefault(num, 0) + 1;
            if (count[num] > target) ret.Add(num);
        }
        return [.. ret];
    }
}