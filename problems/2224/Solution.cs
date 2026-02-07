public class Solution
{
    public int ConvertTime(string current, string correct)
    {
        int a = GetMinutes(current);
        int b = GetMinutes(correct);
        int diff = b - a;
        int ret = 0;
        ret += diff / 60;
        diff %= 60;
        ret += diff / 15;
        diff %= 15;
        ret += diff / 5;
        diff %= 5;
        ret += diff;
        return ret;
    }

    int GetMinutes(string time)
    {
        int hours = (time[0] - '0') * 10 + (time[1] - '0');
        int minutes = (time[3] - '0') * 10 + (time[4] - '0');
        return hours * 60 + minutes;
    }
}