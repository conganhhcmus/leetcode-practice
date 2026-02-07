public class Solution
{
    public int MinimumPairRemoval(int[] nums)
    {
        int n = nums.Length;
        int count = 0;
        while (!Ok(nums))
        {
            int idx = FindPair(nums);
            int[] tmp = new int[nums.Length - 1];
            int j = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == idx)
                {
                    tmp[j++] = nums[i] + nums[i + 1];
                    i++;
                }
                else
                {
                    tmp[j++] = nums[i];
                }
            }

            nums = tmp;
            count++;
        }
        return count;
    }

    int FindPair(int[] nums)
    {
        int ans = 0;
        int min = int.MaxValue;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] + nums[i + 1] < min)
            {
                min = nums[i] + nums[i + 1];
                ans = i;
            }
        }
        return ans;
    }
    bool Ok(int[] nums)
    {
        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] > nums[i + 1]) return false;
        }
        return true;
    }
}