public class Solution
{
    public bool LemonadeChange(int[] bills)
    {
        int count5 = 0, count10 = 0, count20 = 0;
        int n = bills.Length;
        for (int i = 0; i < n; i++)
        {
            if (bills[i] == 5) count5++;
            else if (bills[i] == 10) count10++;
            else if (bills[i] == 20) count20++;
            int need = bills[i] - 5;
            int a = Math.Min(need / 20, count20);
            need -= a * 20;
            count20 -= a;
            int b = Math.Min(need / 10, count10);
            need -= b * 10;
            count10 -= b;
            int c = Math.Min(need / 5, count5);
            need -= c * 5;
            count5 -= c;
            if (need != 0) return false;
        }
        return true;
    }
}
