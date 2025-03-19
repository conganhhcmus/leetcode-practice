#if DEBUG
namespace Problems_3191_2;
#endif

public class Solution
{
    public int MinOperations(int[] nums)
    {
        Queue<int> queue = [];
        int n = nums.Length, count = 0;
        for (int i = 0; i < n; i++)
        {
            while (queue.Count > 0 && i > queue.Peek() + 2)
            {
                queue.Dequeue();
            }

            if ((nums[i] + queue.Count) % 2 == 0)
            {
                if (i + 2 >= n) return -1;
                count++;
                queue.Enqueue(i);
            }
        }
        return count;
    }
}