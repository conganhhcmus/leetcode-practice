public class Solution
{
    public IList<int> SequentialDigits(int low, int high)
    {
        List<int> ans = [];
        for (int d = 0; d < 9; d++)
        {
            Backtracking(d, 0);
        }

        ans.Sort();
        return ans;

        void Backtracking(int last, int cur)
        {
            if (cur >= low && cur <= high)
            {
                ans.Add(cur);
            }
            if (cur > high || last == 9) return;
            last++;
            Backtracking(last, cur * 10 + last);
        }
    }
}
