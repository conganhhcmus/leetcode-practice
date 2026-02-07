public class Solution
{
    public void NextPermutation(int[] nums)
    {
        int n = nums.Length;
        int swapIndex = -1;
        for (int i = 1; i < n; i++)
        {
            if (nums[i] > nums[i - 1])
            {
                swapIndex = i;
            }
        }
        if (swapIndex == -1)
        {
            Array.Reverse(nums);
            return;
        }

        // find min to swap
        int min = swapIndex;
        for (int i = swapIndex + 1; i < n; i++)
        {
            if (nums[i] > nums[swapIndex - 1] && nums[i] < nums[min])
            {
                min = i;
            }
        }

        // swap
        (nums[min], nums[swapIndex - 1]) = (nums[swapIndex - 1], nums[min]);

        // sort remain
        for (int i = swapIndex; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (nums[i] > nums[j])
                {
                    (nums[i], nums[j]) = (nums[j], nums[i]);
                }
            }
        }
    }
}