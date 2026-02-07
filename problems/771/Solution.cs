public class Solution
{
    public int NumJewelsInStones(string jewels, string stones)
    {
        HashSet<char> set = [];
        foreach (char ch in jewels)
        {
            set.Add(ch);
        }

        int count = 0;
        foreach (char ch in stones)
        {
            if (set.Contains(ch)) count++;
        }
        return count;
    }
}