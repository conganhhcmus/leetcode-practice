namespace Problem_1346;
public class Solution
{
    public static void Execute()
    {
        int[] arr = [10, 2, 5, 3];
        var solution = new Solution();
        Console.WriteLine(solution.CheckIfExist(arr));
    }
    public bool CheckIfExist(int[] arr)
    {
        HashSet<int> seen = [];
        foreach (int num in arr)
        {
            if (seen.Contains(2 * num) || (num % 2 == 0 && seen.Contains(num / 2)))
            {
                return true;
            }
            seen.Add(num);
        }
        return false;
    }
}