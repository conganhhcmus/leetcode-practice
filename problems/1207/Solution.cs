namespace Problem_1207;

public class Solution
{
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