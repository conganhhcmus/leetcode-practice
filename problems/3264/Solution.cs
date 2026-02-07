public class Solution
{
    public int[] GetFinalState(int[] nums, int k, int multiplier)
    {
        int n = nums.Length;
        for (int i = 0; i < k; i++)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int j = 0; j < n; j++)
            {
                if (nums[j] < min)
                {
                    minIndex = j;
                    min = nums[j];
                }
            }

            nums[minIndex] *= multiplier;
        }

        return nums;
    }
}