namespace Problem_3276;

public class Solution
{
    public int MaxScore(IList<IList<int>> grid)
    {
        var hashSet = new HashSet<int>();
        foreach (var rows in grid)
        {
            foreach (var num in rows)
            {
                hashSet.Add(num);
            }
        }
        var storage = new Dictionary<int, List<int>>();
        foreach (var val in hashSet)
        {
            storage[val] = [];
        }

        for (int i = 0; i < grid.Count; i++)
        {
            for (int j = 0; j < grid[i].Count; j++)
            {
                var val = grid[i][j];
                storage[val].Add(i);
            }
        }

        var sortedList = new List<int>();

        foreach (var val in hashSet)
        {
            sortedList.Add(val);
        }
        sortedList.Sort((a, b) => b - a);

        var maxValueRecords = new int[1025][];
        for (var i = 0; i < 1025; i++)
        {
            maxValueRecords[i] = new int[101];
            Array.Fill(maxValueRecords[i], 0);
        }

        // foreach (var key in storage.Keys)
        // {
        //     Console.WriteLine($"{key}: {string.Join(", ", storage[key])}");
        // }

        // Console.WriteLine($"SortedList: {string.Join(", ", sortedList)}");
        return Solve(0, 0, sortedList, storage, maxValueRecords);
    }

    private int Solve(
        int index,
        int mask,
        List<int> sortedList,
        Dictionary<int, List<int>> storage,
        int[][] maxValueRecords)
    {
        if (index >= sortedList.Count) return 0;
        if (maxValueRecords[mask][index] != 0) return maxValueRecords[mask][index];
        int ans = 0;
        int val = sortedList[index];
        foreach (var i in storage[val])
        {
            if ((mask & (1 << i)) == 0)
            {
                ans = Math.Max(ans, val + Solve(index + 1, mask | (1 << i), sortedList, storage, maxValueRecords));
            }
        }

        ans = Math.Max(ans, Solve(index + 1, mask, sortedList, storage, maxValueRecords));
        maxValueRecords[mask][index] = ans;
        return ans;
    }
}