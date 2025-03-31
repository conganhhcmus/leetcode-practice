#if DEBUG
namespace Problems_75_3;
#endif

public class Solution
{
    public void SortColors(int[] nums)
    {
        int n = nums.Length;
        int countZero = 0, countOne = 0, countTwo = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] == 0) countZero++;
            else if (nums[i] == 1) countOne++;
            else countTwo++;
        }

        for (int i = 0; i < n; i++)
        {
            if (countZero > 0)
            {
                nums[i] = 0;
                countZero--;
            }
            else if (countOne > 0)
            {
                nums[i] = 1;
                countOne--;
            }
            else
            {
                nums[i] = 2;
                countTwo--;
            }
        }
    }
}