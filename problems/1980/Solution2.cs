public class Solution
{
    public string FindDifferentBinaryString(string[] nums)
    {
        int n = nums.Length;
        StringBuilder sb = new();
        for (int i = 0; i < n; i++)
        {
            sb.Append('1' - nums[i][i]);
        }

        return sb.ToString();
    }
}