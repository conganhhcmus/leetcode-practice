#if DEBUG
using Biweekly_152_Q3;

namespace Problems_1233_2;
#endif

public class Solution
{
    public IList<string> RemoveSubfolders(string[] folder)
    {
        List<string> ret = [];
        TrieNode root = new TrieNode();
        foreach (string path in folder)
        {
            TrieNode curr = root;
            string[] folderNames = path.Split("/");
            foreach (string folderName in folderNames)
            {
                if (folderName == "") continue;
                if (!curr.Children.ContainsKey(folderName))
                {
                    curr.Children[folderName] = new TrieNode();
                }
                curr = curr.Children[folderName];
            }
            curr.IsEndOfFolder = true;
        }

        foreach (string path in folder)
        {
            TrieNode curr = root;
            string[] folderNames = path.Split("/");
            bool isSubFolder = false;
            for (int i = 0; i < folderNames.Length; i++)
            {
                if (folderNames[i] == "") continue;
                TrieNode next = curr.Children[folderNames[i]];
                if (next.IsEndOfFolder && i != (folderNames.Length - 1))
                {
                    isSubFolder = true;
                    break;
                }
                curr = next;
            }
            if (!isSubFolder) ret.Add(path);
        }

        return ret;
    }
}

public class TrieNode
{
    public bool IsEndOfFolder;
    public Dictionary<string, TrieNode> Children;

    public TrieNode()
    {
        IsEndOfFolder = false;
        Children = [];
    }
}