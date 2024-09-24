namespace Problem_350;

public class Solution
{

    public static void Execute()
    {
        var solution = new Solution();
        int[] nums1 = [1, 2, 2, 1];
        int[] nums2 = [2, 2];
        Console.WriteLine($"[{string.Join(",", solution.Intersect(nums1, nums2))}]");
    }
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        Dictionary<int, int> dicNums1 = [];
        Dictionary<int, int> dicNums2 = [];

        foreach (var num in nums1)
        {
            if (dicNums1.ContainsKey(num))
            {
                dicNums1[num]++;
            }
            else
            {
                dicNums1.Add(num, 1);
            }
        }

        foreach (var num in nums2)
        {
            if (dicNums2.ContainsKey(num))
            {
                dicNums2[num]++;
            }
            else
            {
                dicNums2.Add(num, 1);
            }
        }

        List<int> ans = [];

        foreach (var num in dicNums1.Keys)
        {
            if (dicNums2.ContainsKey(num))
            {
                int freq = int.Min(dicNums1[num], dicNums2[num]);
                while (freq > 0)
                {
                    ans.Add(num);
                    freq--;
                }
            }
        }

        return [.. ans];
    }
}