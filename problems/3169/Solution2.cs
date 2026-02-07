public class Solution
{
    public int CountDays(int days, int[][] meetings)
    {
        SortedDictionary<int, int> diffArray = [];
        int previousDay = days;
        foreach (int[] meeting in meetings)
        {
            int start = meeting[0];
            int end = meeting[1] + 1;
            diffArray[start] = diffArray.GetValueOrDefault(start, 0) + 1;
            diffArray[end] = diffArray.GetValueOrDefault(end, 0) - 1;
            previousDay = Math.Min(previousDay, start);
        }

        int ans = 0, prefixSum = 0;
        ans += previousDay - 1;
        foreach (int day in diffArray.Keys)
        {
            if (prefixSum == 0)
            {
                ans += day - previousDay;
            }
            prefixSum += diffArray[day];
            previousDay = day;
        }

        ans += days - previousDay + 1;

        return ans;
    }
}