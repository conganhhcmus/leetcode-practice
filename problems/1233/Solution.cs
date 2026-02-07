public class Solution
{
    public IList<string> RemoveSubfolders(string[] folder)
    {
        Array.Sort(folder);
        List<string> result = [];

        foreach (string f in folder)
        {
            if (result.Count == 0 || !f.StartsWith(result.Last() + "/"))
            {
                result.Add(f);
            }
        }

        return result;
    }
}