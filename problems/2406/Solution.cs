public class Solution
{
    public int MinGroups(int[][] intervals)
    {
        var maxTime = intervals.Max(x => x[1]);
        int[] line = new int[maxTime + 2];
        foreach (var interval in intervals)
        {
            line[interval[0]]++;
            line[interval[1] + 1]--;
        }

        int maxOverlap = 0;
        int currOverlap = 0;
        for (int i = 0; i < line.Length; i++)
        {
            currOverlap += line[i];
            maxOverlap = Math.Max(maxOverlap, currOverlap);
        }
        return maxOverlap;
    }
}