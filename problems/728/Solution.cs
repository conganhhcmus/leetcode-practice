#if DEBUG
namespace Problems_728;
#endif

public class Solution
{
    public IList<int> SelfDividingNumbers(int left, int right)
    {
        List<int> ans = [];
        for (int i = left; i <= right; i++)
        {
            int temp = i;
            while (temp > 0)
            {
                if (temp % 10 == 0 || i % (temp % 10) != 0) break;
                temp /= 10;
            }
            if (temp == 0) ans.Add(i);
        }

        return ans;
    }
}