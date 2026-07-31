public class Solution
{
    public int LongestBalanced(int[] nums)
    {
        int n = nums.Length;
        Dictionary<int, int> oddCnt = [];
        Dictionary<int, int> evenCnt = [];
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            int x = nums[i];
            if (x % 2 == 0) evenCnt[x] = evenCnt.GetValueOrDefault(x, 0) + 1;
            else oddCnt[x] = oddCnt.GetValueOrDefault(x, 0) + 1;
            if (oddCnt.Count == evenCnt.Count)
            {
                ans = Math.Max(ans, i + 1);
            }

            Dictionary<int, int> oddTmp = new(oddCnt);
            Dictionary<int, int> evenTmp = new(evenCnt);
            int j = 0;
            while (j <= i)
            {
                int y = nums[j];
                if (y % 2 == 0)
                {
                    evenTmp[y]--;
                    if (evenTmp[y] == 0) evenTmp.Remove(y);
                }
                else
                {
                    oddTmp[y]--;
                    if (oddTmp[y] == 0) oddTmp.Remove(y);
                }
                if (evenTmp.Count == oddTmp.Count)
                {
                    ans = Math.Max(ans, i - j);
                    break;
                }
                j++;
            }
        }
        return ans;
    }
}
