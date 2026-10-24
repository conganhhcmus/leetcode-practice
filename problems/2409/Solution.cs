public class Solution {
    public int CountDaysTogether(string arriveAlice, string leaveAlice, string arriveBob, string leaveBob) {
        int[] daysOfMonth = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
        int stA = CountDays(arriveAlice);
        int edA = CountDays(leaveAlice);

        int stB = CountDays(arriveBob);
        int edB = CountDays(leaveBob);

        // count coverlap [xA, yA], [xB, yB] => Math.Max(xA, xB) <= Math.Min(yA, yB)
        return Math.Max(0, Math.Min(edA, edB) - Math.Max(stA, stB) + 1);

        int CountDays(string str){
            int month = int.Parse(str.Split("-")[0]);
            int day = int.Parse(str.Split("-")[1]);

            int ans = 0;
            for(int m = 0; m < month - 1;m++){
                ans += daysOfMonth[m];
            }
            ans += day;
            return ans;
        }
    }
}