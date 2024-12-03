namespace Problem_1894;

public class Solution
{
    public int ChalkReplacer(int[] chalk, int k)
    {
        return ChalkReplacer_Recurse(chalk, k);
        //return ChalkReplacer_Loop(chalk, k);
    }

    public int ChalkReplacer_Recurse(int[] chalk, int k)
    {
        int sum = 0;
        for (int i = 0; i < chalk.Length; i++)
        {
            sum += chalk[i];
            if (sum > k) return i;
        }

        return ChalkReplacer_Recurse(chalk, k % sum);
    }

    public int ChalkReplacer_Loop(int[] chalk, int k)
    {
        int i = 0;
        while (k >= 0)
        {
            k -= chalk[i];
            i = (i + 1) % chalk.Length;
        }
        return (i + chalk.Length - 1) % chalk.Length;
    }
}