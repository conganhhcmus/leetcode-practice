public class Solution
{
    public bool DivisorGame(int n)
    {
        // f[0] = false. Mean first player is lose
        // f[1] = false. Mean first player is lose
        // f[i] = true if have any x where i mod x is zero and f[i-x] is false
        bool[] f = new bool[n + 1];
        for (int i = 2; i <= n; i++)
        {
            for (int x = 1; x < i; x++)
            {
                if (i % x == 0 && f[i - x] == false)
                {
                    f[i] = true;
                    break;
                }
            }
        }
        return f[n];
    }
}