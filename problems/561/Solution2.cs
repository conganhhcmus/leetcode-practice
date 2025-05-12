#if DEBUG
namespace Problems_561_2;
#endif

public class Solution
{
    public int ArrayPairSum(int[] nums)
    {
        int n = nums.Length;
        int minVal = int.MaxValue;
        int maxVal = int.MinValue;
        foreach (int num in nums)
        {
            if (minVal > num) minVal = num;
            if (maxVal < num) maxVal = num;
        }
        int[] count = new int[maxVal - minVal + 1];
        foreach (int num in nums)
        {
            count[num - minVal]++;
        }
        bool pick = true;
        int ret = 0;
        for (int i = 0; i <= maxVal - minVal; i++)
        {
            while (count[i] > 0)
            {
                if (pick) ret += i + minVal;
                count[i]--;
                pick = !pick;
            }
        }
        return ret;
    }
}