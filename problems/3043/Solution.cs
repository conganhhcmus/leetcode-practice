public class Solution
{
    public int LongestCommonPrefix(int[] arr1, int[] arr2)
    {
        HashSet<int> set1 = [];
        HashSet<int> set2 = [];
        foreach (int num in arr1)
        {
            int tmp = num;
            while (tmp > 0)
            {
                set1.Add(tmp);
                tmp /= 10;
            }
        }
        foreach (int num in arr2)
        {
            int tmp = num;
            while (tmp > 0)
            {
                set2.Add(tmp);
                tmp /= 10;
            }
        }
        int ans = 0;
        foreach (int num in set1)
        {
            if (set2.Contains(num))
            {
                ans = Math.Max(ans, num.ToString().Length);
            }
        }
        return ans;
    }
}
