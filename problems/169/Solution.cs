namespace Problem_169;
public class Solution
{
    public int MajorityElement(int[] nums)
    {
        int majorityElement = nums[0];
        int count = 0;

        foreach (int num in nums)
        {
            if (count == 0)
            {
                majorityElement = num;
            }

            count += (num == majorityElement) ? 1 : -1;
        }

        return majorityElement;
    }
}