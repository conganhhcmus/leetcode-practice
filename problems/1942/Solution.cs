namespace Problem_1942;

public class Solution
{
    public int SmallestChair(int[][] times, int targetFriend)
    {
        var targetTime = times[targetFriend];
        Array.Sort(times, (a, b) => a[0] - b[0]);
        int[] map = new int[times.Length];
        for (int i = 0; i < times.Length; i++)
        {
            int j = 0;
            while (map[j] > times[i][0])
            {
                j++;
            }
            map[j] = times[i][1];

            if (times[i][0] == targetTime[0]) return j;
        }
        return 0;
    }
}