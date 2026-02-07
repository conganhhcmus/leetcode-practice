public class Solution
{
    public string SimplifyPath(string path)
    {
        string[] folders = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
        Stack<string> st = [];
        foreach (string f in folders)
        {
            if (f == "." || f == "/") continue;
            if (f == "..")
            {
                if (st.Count > 0) st.Pop();
            }
            else st.Push(f);
        }

        StringBuilder sb = new();
        while (st.Count > 0) sb.Insert(0, "/" + st.Pop());
        if (sb.Length == 0) sb.Append("/");
        return sb.ToString();
    }
}