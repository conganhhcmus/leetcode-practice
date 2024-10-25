namespace Problem_1233;

public class Solution
{
    public static void Execute()
    {
        string[] folder = ["/a", "/a/b", "/c/d", "/c/d/e", "/c/f"];
        var solution = new Solution();
        var res = solution.RemoveSubfolders(folder);
        Console.WriteLine($"[{string.Join(", ", res)}]");
    }

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