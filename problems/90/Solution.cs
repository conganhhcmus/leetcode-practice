public class Solution
{
    public IList<IList<int>> SubsetsWithDup(int[] nums)
    {
        IList<IList<int>> ans = [];
        int[] count = new int[21];
        foreach (int num in nums)
        {
            count[num + 10]++;
        }
        Backtracking([], 0);
        return ans;

        void Backtracking(List<int> cur, int min)
        {
            ans.Add([.. cur]);
            for (int i = min; i < 21; i++)
            {
                if (count[i] == 0) continue;
                count[i]--;
                cur.Add(i - 10);
                Backtracking(cur, i);
                count[i]++;
                cur.RemoveAt(cur.Count - 1);
            }
        }
    }
}
