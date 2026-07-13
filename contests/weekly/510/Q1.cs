public class Solution
{
    public int SecondsBetweenTimes(string startTime, string endTime)
    {
        string[] st = startTime.Split(":");
        string[] ed = endTime.Split(":");

        int hDiff = int.Parse(ed[0]) - int.Parse(st[0]);
        int mDiff = int.Parse(ed[1]) - int.Parse(st[1]);
        int sDiff = int.Parse(ed[2]) - int.Parse(st[2]);

        return hDiff * 60 * 60 + mDiff * 60 + sDiff;
    }
}
