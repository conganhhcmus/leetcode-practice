public class Solution
{
    public int FindSmallestInteger(int[] nums, int value)
    {
        int n = nums.Length;
        int[] count = new int[value];
        foreach (int num in nums)
        {
            count[Mod(num, value)]++;
        }
        for (int i = 0; i < n; i++)
        {
            int index = Mod(i, value);
            if (count[index] == 0) return i;
            count[index]--;
        }
        return n;
    }

    int Mod(int a, int b) => (a % b + b) % b;
}