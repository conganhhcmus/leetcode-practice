#if DEBUG
namespace Problems_2106_3;
#endif

public class Solution
{
    public int MaxTotalFruits(int[][] fruits, int startPos, int k)
    {
        int left = 0;
        int right = 0;
        int n = fruits.Length;
        int sum = 0;
        int ans = 0;
        while (right < n)
        {
            sum += fruits[right][1];
            while (left <= right && Step(fruits, startPos, left, right) > k)
            {
                sum -= fruits[left][1];
                left++;
            }
            ans = Math.Max(ans, sum);
            right++;
        }
        return ans;
    }

    int Step(int[][] fruits, int startPos, int left, int right)
    {
        if (fruits[right][0] <= startPos)
        {
            return startPos - fruits[left][0];
        }

        if (fruits[left][0] >= startPos)
        {
            return fruits[right][0] - startPos;
        }

        return Math.Min(Math.Abs(startPos - fruits[right][0]), Math.Abs(startPos - fruits[left][0])) + fruits[right][0] - fruits[left][0];
    }
}