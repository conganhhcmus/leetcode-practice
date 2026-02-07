public class Solution
{
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