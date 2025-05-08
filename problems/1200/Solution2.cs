#if DEBUG
namespace Problems_1200_2;
#endif

public class Solution
{
    public IList<IList<int>> MinimumAbsDifference(int[] arr)
    {
        int minVal = int.MaxValue, maxVal = int.MinValue;
        foreach (int num in arr)
        {
            if (minVal > num) minVal = num;
            if (maxVal < num) maxVal = num;
        }
        int[] freq = new int[maxVal - minVal + 1];
        foreach (int num in arr)
        {
            freq[num - minVal]++;
        }

        int minDiff = int.MaxValue;
        int prevVal = int.MinValue;
        bool hasPrev = false;
        IList<IList<int>> ret = [];
        for (int i = 0; i < maxVal - minVal + 1; i++)
        {
            int count = freq[i];
            if (count == 0) continue;
            int currVal = i + minVal;
            if (count > 1)
            {
                if (0 < minDiff)
                {
                    minDiff = 0;
                    ret.Clear();
                }
                for (int k = 1; k < count; k++)
                {
                    ret.Add([currVal, currVal]);
                }
            }

            if (hasPrev)
            {
                int diff = currVal - prevVal;
                if (diff < minDiff)
                {
                    minDiff = diff;
                    ret.Clear();
                    ret.Add([prevVal, currVal]);
                }
                else if (diff == minDiff)
                {
                    ret.Add([prevVal, currVal]);
                }
            }

            prevVal = currVal;
            hasPrev = true;
        }

        return ret;
    }
}