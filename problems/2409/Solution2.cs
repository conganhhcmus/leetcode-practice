public class Solution
{
    public int CountDaysTogether(string arriveAlice, string leaveAlice, string arriveBob, string leaveBob)
    {
        int[] dayStack = [0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334];
        int stA = CountDays(arriveAlice);
        int edA = CountDays(leaveAlice);
        int stB = CountDays(arriveBob);
        int edB = CountDays(leaveBob);

        // count coverlap [xA, yA], [xB, yB] => Math.Max(xA, xB) <= Math.Min(yA, yB)
        return Math.Max(0, Math.Min(edA, edB) - Math.Max(stA, stB) + 1);

        int CountDays(string MM_DD)
        {
            int month = (MM_DD[0] - 48) * 10 + (MM_DD[1] - 48);
            int day = (MM_DD[3] - 48) * 10 + (MM_DD[4] - 48);
            return dayStack[month - 1] + day;
        }
    }
}