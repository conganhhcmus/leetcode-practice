public class Solution
{
    public string[] FindRestaurant(string[] list1, string[] list2)
    {
        int min = int.MaxValue;
        List<string> ret = [];

        Dictionary<string, int> map = [];
        for (int i = 0; i < list2.Length; i++)
        {
            map[list2[i]] = i;
        }
        for (int i = 0; i < list1.Length; i++)
        {
            if (map.TryGetValue(list1[i], out int idx))
            {
                if (min > i + idx)
                {
                    min = i + idx;
                    ret = [list1[i]];
                }
                else if (min == i + idx)
                {
                    ret.Add(list1[i]);
                }
            }
        }

        return [.. ret];
    }
}