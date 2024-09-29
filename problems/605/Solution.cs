namespace Problem_605;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        int[] flowerbed = [1, 0, 0, 0, 1];
        int n = 2;
        Console.WriteLine(solution.CanPlaceFlowers(flowerbed, n));
    }
    public bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        if (2 * n > flowerbed.Length + 1) return false;

        int count = 0;
        for (int i = 0; i < flowerbed.Length; i++)
        {
            if (flowerbed[i] == 0)
            {
                bool isEmptyLeft = i == 0 || flowerbed[i - 1] == 0;
                bool isEmptyRight = i == flowerbed.Length - 1 || flowerbed[i + 1] == 0;
                if (isEmptyLeft && isEmptyRight)
                {
                    count++;
                    flowerbed[i] = 1;
                    if (count >= n) return true;
                }
            }
            else
            {
                i++;
            }
        }

        return count >= n;
    }
}