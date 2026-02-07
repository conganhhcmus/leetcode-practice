public class Solution
{
    public int[] MissingRolls(int[] rolls, int mean, int n)
    {
        int sum = mean * (rolls.Length + n) - rolls.Sum();
        if (6 * n < sum || sum < n) return [];

        int div = sum / n;
        int mod = sum % n;
        var res = new int[n];
        Array.Fill(res, div + 1, 0, mod);
        Array.Fill(res, div, mod, n - mod);

        return res;
    }
}