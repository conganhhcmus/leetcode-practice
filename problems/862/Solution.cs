namespace Problem_862;

public class Solution
{
    public static void Execute()
    {
        int[] nums = [18393, 13015, 39877, -46990, 84110, -16361, -42889, -10085, 46644, 91545, 71230, 48090, 34489, 2788, 56496, -32528, 77455, -44282, 80504, 77949, 70, 74450, -4005, 82184, -19401, 49038, -10000, 31028, 26603, 62302, 76071, 73298, -20008, -12421, -11904, -8055, 50871, 20857, 56174, 88271, 37380, 56974, 85085, -29377, -39430, 86935, -42349, -12415, -21752, 95087];
        int k = 917790;
        var solution = new Solution();
        Console.WriteLine(solution.ShortestSubarray(nums, k));
    }
    public int ShortestSubarray(int[] nums, int k)
    {
        int n = nums.Length;
        var deque = new LinkedList<(long sum, int index)>();
        deque.AddLast((0, -1));
        int minLen = int.MaxValue;
        long curSum = 0;
        for (int i = 0; i < n; i++)
        {
            curSum += nums[i];
            while (deque.Count > 0 && curSum - deque.First.Value.sum >= k)
            {
                minLen = Math.Min(minLen, i - deque.First.Value.index);
                deque.RemoveFirst();
            }

            while (deque.Count > 0 && curSum < deque.Last.Value.sum)
            {
                deque.RemoveLast();
            }

            deque.AddLast((curSum, i));
        }

        return minLen == n + 1 ? -1 : minLen;
    }
}
