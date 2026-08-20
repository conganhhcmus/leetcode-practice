public class Solution
{
    public int[] ResultArray(int[] nums)
    {
        int n = nums.Length;
        List<int> arr1 = [nums[0]];
        List<int> arr2 = [nums[1]];
        for (int i = 2; i < n; i++)
        {
            if (arr1[^1] > arr2[^1]) arr1.Add(nums[i]);
            else arr2.Add(nums[i]);
        }
        for (int i = 0; i < arr1.Count; i++)
        {
            nums[i] = arr1[i];
        }
        for (int i = 0; i < arr2.Count; i++)
        {
            nums[arr1.Count + i] = arr2[i];
        }
        return nums;
    }
}
