public class Solution
{
    public IList<int> SequentialDigits(int low, int high)
    {
        string nums = "123456789";
        List<int> ans = [];
        for (int l = low.ToString().Length; l <= high.ToString().Length; l++)
        {
            for (int i = 0; i + l <= 9; i++)
            {
                int val = int.Parse(nums.Substring(i, l));
                if (val >= low && val <= high) ans.Add(val);
            }
        }
        return ans;
    }
}
