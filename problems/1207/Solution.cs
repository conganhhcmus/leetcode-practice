namespace Problem_1207;

public class Solution
{
    public static void Execute()
    {
        int[] arr = [1, 2, 2, 1, 1, 3];
        var solution = new Solution();

        Console.WriteLine(solution.UniqueOccurrences(arr));
    }
    public bool UniqueOccurrences(int[] arr)
    {
        Dictionary<int, int> frequency = [];
        foreach (int num in arr)
        {
            frequency[num] = frequency.GetValueOrDefault(num, 0) + 1;
        }
        HashSet<int> hashSet = [];
        foreach (var e in frequency)
        {
            hashSet.Add(e.Value);
        }

        return hashSet.Count == frequency.Count;
    }
}