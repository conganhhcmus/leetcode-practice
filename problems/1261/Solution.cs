#if DEBUG
namespace Problems_1261;
#endif

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class FindElements
{
    HashSet<int> _set;

    public FindElements(TreeNode root)
    {
        _set = [];
        if (root == null) return;
        Queue<TreeNode> queue = [];
        queue.Enqueue(root);
        root.val = 0;
        while (queue.Count > 0)
        {
            TreeNode node = queue.Dequeue();
            _set.Add(node.val);
            if (node.left != null)
            {
                queue.Enqueue(node.left);
                node.left.val = node.val * 2 + 1;
            }
            if (node.right != null)
            {
                queue.Enqueue(node.right);
                node.right.val = node.val * 2 + 2;
            }
        }
    }

    public bool Find(int target)
    {
        return _set.Contains(target);
    }
}

/**
 * Your FindElements object will be instantiated and called as such:
 * FindElements obj = new FindElements(root);
 * bool param_1 = obj.Find(target);
 */

public class Solution
{
    public List<dynamic> Execute(string[] actions, dynamic values)
    {
        List<dynamic> result = [];
        FindElements findElement = null;
        object[] objectList = JsonConvert.DeserializeObject<object[]>(values);
        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "FindElements":
                    findElement = new FindElements(TreeNodeHelper.CreateTreeFromArray(CastType<int?[]>(objectList[i])));
                    result.Add(null);
                    break;
                case "find":
                    result.Add(findElement.Find(CastType<int>(objectList[i])));
                    break;
                default:
                    break;
            }
        }
        return result;
    }

    private T CastType<T>(object value)
    {
        return JsonConvert.DeserializeObject<T[]>(JsonConvert.SerializeObject(value))[0];
    }
}