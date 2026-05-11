using System.Text;

public class Solution
{
    public int[] SeparateDigits(int[] nums)
    {
        StringBuilder sb = new();
        foreach (int num in nums)
        {
            sb.Append(num.ToString());
        }
        int n = sb.Length;
        int[] ans = new int[n];
        for (int i = 0; i < n; i++)
        {
            ans[i] = sb[i] - '0';
        }
        return ans;
    }
}
