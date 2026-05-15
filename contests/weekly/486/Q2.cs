public class Solution
{
    public int[] RotateElements(int[] nums, int k)
    {
        int n = nums.Length;
        List<int> arr = [];
        for (int i = 0; i < n; i++)
        {
            if (nums[i] < 0) continue;
            arr.Add(nums[i]);
        }
        int m = arr.Count;
        int j = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] < 0) continue;
            int idx = (j + k) % m;
            nums[i] = arr[idx];
            j++;
        }
        return nums;
    }
}
