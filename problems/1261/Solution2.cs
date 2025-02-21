#if DEBUG
namespace Problems_1261_2;
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
    TreeNode _root;

    public FindElements(TreeNode root)
    {
        _root = root;
    }

    public bool Find(int target)
    {
        target++;
        int depth = int.Log2(target);
        TreeNode node = _root;
        var mask = 1 << (depth - 1);
        while (mask > 0 && node != null)
        {
            node = (target & mask) == 0 ? node.left : node.right;
            mask >>= 1;
        }

        return node != null;
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