namespace Practice_179;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        int[] nums = [111311, 1113];
        Console.WriteLine(solution.LargestNumber(nums));
    }
    public string LargestNumber(int[] nums)
    {
        List<string> numsStr = [];

        foreach (var num in nums)
        {
            numsStr.Add(num.ToString());
        }

        numsStr.Sort((a, b) => (b + a).CompareTo(a + b));

        if (numsStr[0] == "0") return "0";
        return string.Join("", numsStr);
    }
}