public class Solution
{
    public int FillCups(int[] amount)
    {
        int ret = 0;
        Array.Sort(amount, (a, b) => b - a);
        while (!IsCompleted(amount))
        {
            ret++;
            amount[0]--;
            amount[1]--;
            Array.Sort(amount, (a, b) => b - a);
        }
        return ret;
    }

    bool IsCompleted(int[] amount)
    {
        return amount[0] <= 0 && amount[1] <= 0 && amount[2] <= 0;
    }
}