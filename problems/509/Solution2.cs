public class Solution
{
    public int Fib(int n)
    {
        // golden_ratio = (√5 + 1) / 2 ~ 1.618034
        // f[n] = [(√5 + 1) ^ n - (1 - √5) ^ n] / [2 ^ n * √5]
        // f[n] = [((√5 + 1)/2) ^ n - ((1 - √5)/2) ^ n] / √5
        // f[n] = [golden_ration ^ n - (1 - golden_ration) ^ n] / √5
        double GOLDEN_RATIO = 1.618034;
        return (int)((Math.Pow(GOLDEN_RATIO, n) - Math.Pow(1 - GOLDEN_RATIO, n)) / Math.Sqrt(5));
    }
}