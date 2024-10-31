namespace Problem_2300;

public class Solution
{
    public static void Execute()
    {
        int[] spells = [15, 8, 19];
        int[] potions = [38, 36, 23];
        long success = 328;
        var solution = new Solution();
        var result = solution.SuccessfulPairs(spells, potions, success);

        Console.WriteLine($"[{string.Join(",", result)}]");
    }

    public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
    {
        Array.Sort(potions);
        int[] result = new int[spells.Length];
        for (int i = 0; i < spells.Length; i++)
        {
            double find = success * 1.0 / spells[i];
            if (potions[^1] < find)
            {
                result[i] = 0;
                continue;
            }
            int low = 0;
            int high = potions.Length - 1;
            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (potions[mid] < find)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid;
                }
            }
            result[i] = potions.Length - high;
        }
        return result;
    }
}