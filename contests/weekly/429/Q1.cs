public class Solution
{
    public int MinimumOperations(int[] nums)
    {
        int ans = 0;
        int[] cloned = [.. nums];

        while (cloned.Length > 0)
        {
            if (IsDistinct(cloned))
            {
                break;
            }
            if (cloned.Length < 3)
            {
                cloned = [];
            }
            else
            {
                cloned = cloned[3..];
            }
            ans++;
        }

        return ans;
    }

    private bool IsDistinct(int[] nums)
    {
        Dictionary<int, int> freq = [];
        foreach (int num in nums)
        {
            if (freq.ContainsKey(num))
            {
                return false;
            }
            freq[num] = 1;
        }
        return true;
    }
}