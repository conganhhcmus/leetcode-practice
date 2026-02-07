public class Solution
{
    public int MaxOperations(int[] nums, int k)
    {
        Dictionary<int, int> frequency = [];
        foreach (int num in nums)
        {
            frequency[num] = frequency.GetValueOrDefault(num, 0) + 1;
        }

        int ans = 0;
        foreach (KeyValuePair<int, int> pair in frequency)
        {
            int target = k - pair.Key;

            if (target == pair.Key)
            {
                ans += pair.Value;
                continue;
            }

            if (frequency.TryGetValue(target, out int value))
            {
                ans += Math.Min(pair.Value, value);
            }
        }
        return ans / 2;
    }
}