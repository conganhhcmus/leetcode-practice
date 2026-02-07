public class Solution
{
    public int TupleSameProduct(int[] nums)
    {
        int ans = 0;
        int n = nums.Length;
        Dictionary<int, int> map = [];
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                int key = nums[i] * nums[j];
                ans += map.GetValueOrDefault(key, 0);
                map[key] = map.GetValueOrDefault(key, 0) + 1;
            }
        }

        return 8 * ans;
    }
}