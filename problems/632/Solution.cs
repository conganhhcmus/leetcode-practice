public class Solution
{
    public int[] SmallestRange(IList<IList<int>> nums)
    {
        SortedList<int, HashSet<int>> dp = [];
        for (int i = 0; i < nums.Count; i++)
        {
            foreach (var num in nums[i])
            {
                dp[num] = [.. dp.GetValueOrDefault(num, []), i];
            }
        }
        int min = int.MaxValue;
        int start = 0;
        int end = 0;
        var keys = dp.Keys;

        for (int i = 0; i < keys.Count; i++)
        {
            HashSet<int> map = [];
            for (int j = i; j < keys.Count; j++)
            {
                map.UnionWith(dp[keys[j]]);
                if (map.Count == nums.Count)
                {
                    if (keys[j] - keys[i] < min)
                    {
                        min = keys[j] - keys[i];
                        start = keys[i];
                        end = keys[j];
                    }
                    if (min == 0) return [start, end];
                    continue;
                }
            }
        }

        return [start, end];
    }

    private int[] SmallestRange2(IList<IList<int>> nums)
    {
        PriorityQueue<(int value, int listId, int id), int> queue = new();
        for (int i = 0; i < nums.Count; i++)
        {
            queue.Enqueue((nums[i][0], i, 0), nums[i][0]);
        }

        int end = nums.Max(x => x[0]);
        int start = nums.Min(x => x[0]);
        int diff = end - start;
        int maxValue = end;

        while (true)
        {
            var (_, listId, id) = queue.Dequeue();

            if (id == nums[listId].Count - 1) break;

            int value = nums[listId][id + 1];
            queue.Enqueue((value, listId, id + 1), value);
            maxValue = Math.Max(maxValue, value);
            var (minValue, _, _) = queue.Peek();

            if (maxValue - minValue < diff)
            {
                diff = maxValue - minValue;
                end = maxValue;
                start = minValue;
            }
        }

        return [start, end];
    }
}