public class Solution
{
    public IList<int> ToggleLightBulbs(IList<int> bulbs)
    {
        bool[] map = new bool[101];
        foreach (int b in bulbs)
        {
            map[b] = !map[b];
        }
        IList<int> ans = [];
        for (int i = 0; i < 101; i++)
        {
            if (map[i]) ans.Add(i);
        }
        return ans;
    }
}