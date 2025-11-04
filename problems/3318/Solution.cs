#if DEBUG
namespace Problems_3318;
#endif

public class Solution
{
    public int[] FindXSum(int[] nums, int k, int x)
    {
        int n = nums.Length;
        int[] ans = new int[n - k + 1];
        for (int i = 0; i < n - k + 1; i++)
        {
            ans[i] = Calc(nums, i, x, k);
        }

        return ans;
    }

    int Calc(int[] nums, int pos, int x, int k)
    {
        int[] count = new int[100];
        for (int i = pos; i < pos + k; i++)
        {
            count[nums[i]]++;
        }
        PriorityQueue<int, (int, int)> pq = new(Comparer<(int, int)>.Create((a, b) =>
        {
            if (a.Item1 == b.Item1)
            {
                return b.Item2 - a.Item2;
            }
            return b.Item1 - a.Item1;
        }));
        for (int i = 0; i < 100; i++)
        {
            if (count[i] > 0) pq.Enqueue(i, (count[i], i));
        }
        int ans = 0;
        int loop = Math.Min(x, k);
        while (pq.Count > 0 && loop > 0)
        {
            int num = pq.Dequeue();
            ans += num * count[num];
            loop--;
        }

        return ans;
    }
}