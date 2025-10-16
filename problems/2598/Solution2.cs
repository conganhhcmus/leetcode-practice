#if DEBUG
namespace Problems_2598_2;
#endif

public class Solution
{
    public int FindSmallestInteger(int[] nums, int value)
    {
        int n = nums.Length;
        int[] count = new int[value];
        int minCount = n;
        int last = 0;
        foreach (int num in nums)
        {
            count[Mod(num, value)]++;
        }

        for (int i = 0; i < value; i++)
        {
            if (count[i] < minCount)
            {
                minCount = count[i];
                last = i;
            }
        }

        return minCount * value + last;
    }

    int Mod(int a, int b) => (a % b + b) % b;
}