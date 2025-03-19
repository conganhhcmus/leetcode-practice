#if DEBUG
namespace Problems_215;
#endif

public class Solution
{
    public int FindKthLargest(int[] nums, int k)
    {
        int min = int.MaxValue;
        int max = int.MinValue;
        foreach (var num in nums)
        {
            min = Math.Min(min, num);
            max = Math.Max(max, num);
        }
        int[] frequency = new int[max - min + 1];
        foreach (var num in nums)
        {
            frequency[num - min]++;
        }

        for (int i = frequency.Length - 1; i >= 0; i--)
        {
            k -= frequency[i];
            if (k <= 0) return i + min;
        }
        return -1;
    }
}