public class Solution
{
    public int CountPairs(int[] nums, int k)
    {
        int n = nums.Length;
        Dictionary<int, List<int>> map = [];
        for (int i = 0; i < n; i++)
        {
            map.TryAdd(nums[i], []);
            map[nums[i]].Add(i);
        }
        int ret = 0;
        List<int> divisors = [];
        for (int i = 1; i <= Math.Sqrt(k); i++)
        {
            if (k % i == 0)
            {
                divisors.Add(i);
                if (i != k / i)
                {
                    divisors.Add(k / i);
                }
            }
        }
        foreach (List<int> values in map.Values)
        {
            int[] count = new int[101];
            foreach (int i in values)
            {
                int need = k / GCD(i, k);
                ret += count[need];
                foreach (int d in divisors)
                {
                    if (i % d == 0) count[d]++;
                }
            }
        }
        return ret;
    }

    int GCD(int a, int b)
    {
        if (b == 0) return a;
        return GCD(b, a % b);
    }
}