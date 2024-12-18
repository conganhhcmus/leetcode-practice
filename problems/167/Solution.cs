#if DEBUG
namespace Problems_167;
#endif

public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        int n = numbers.Length;
        int left = 0, right = n - 1;
        while (left < right)
        {
            if (numbers[right] + numbers[left] == target) break;

            if (numbers[left] + numbers[right] > target)
            {
                right--;
            }
            else
            {
                left++;
            }
        }

        return [left + 1, right + 1];
    }
}