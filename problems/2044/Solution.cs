namespace Problem_2044;

public class Solution
{
    public int CountMaxOrSubsets(int[] nums)
    {
        int maxBitwise = 0;
        foreach (var num in nums)
        {
            maxBitwise |= num;
        }
        int count = 0;

        void CalculateBitWise(List<int> queue, int start)
        {
            int bitwise = queue.Aggregate(0, (acc, num) => acc | num);
            if (bitwise == maxBitwise) count++;

            for (int i = start; i < nums.Length; i++)
            {
                queue.Add(nums[i]);
                start++;
                CalculateBitWise([.. queue], start);
                queue.RemoveAt(queue.Count - 1);
            }
        }

        CalculateBitWise([], 0);
        return count;
    }

    public int CountMaxOrSubsets2(int[] nums)
    {
        int maxBitwise = nums.Aggregate(0, (bitwise, num) => bitwise | num);
        int count = 0;
        int maxBitMap = 1 << nums.Length;
        for (int bitmap = 0; bitmap < maxBitMap; bitmap++)
        {
            int bitwise = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if ((bitmap & (1 << i)) != 0)
                {
                    bitwise |= nums[i];
                }
            }
            if (bitwise == maxBitwise) count++;
        }
        return count;
    }
}