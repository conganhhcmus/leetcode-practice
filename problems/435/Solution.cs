namespace Problem_435;

public class Solution
{
    public static void Execute()
    {
        int[][] intervals = [[0, 2], [1, 3], [2, 4], [3, 5], [4, 6]];
        var solution = new Solution();
        Console.WriteLine(solution.EraseOverlapIntervals(intervals));
    }
    public int EraseOverlapIntervals(int[][] intervals)
    {
        int res = 0;
        Array.Sort(intervals, (a, b) => a[1] - b[1]);
        int prevEnd = intervals[0][1];

        for (int i = 1; i < intervals.Length; i++)
        {
            if (prevEnd > intervals[i][0])
            {
                res++;
            }
            else
            {
                prevEnd = intervals[i][1];
            }
        }

        return res;
    }
}