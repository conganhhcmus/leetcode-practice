namespace Problem_1679;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        int[] nums = [1, 2, 3, 4, 5];
        int k = 5;
        Console.WriteLine(solution.MaxOperations(nums, k));
    }
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