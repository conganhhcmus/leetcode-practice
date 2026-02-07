public class Solution
{
    public int PunishmentNumber(int n)
    {
        int ans = 0;
        for (int i = 1; i <= n; i++)
        {
            int square = i * i;
            if (Ok(square, i)) ans += square;
        }

        return ans;
    }

    private bool Ok(int num, int target)
    {
        if (num == target) return true;
        if (target < 0 || num < target) return false;
        for (int power = 10; power < num; power *= 10)
        {
            int take = num % power;
            int remain = num / power;
            if (Ok(remain, target - take)) return true;
        }

        return false;
    }
}