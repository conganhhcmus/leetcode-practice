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
public class Solution
{
    public TreeNode BalanceBST(TreeNode root)
    {
        List<int> values = [];
        LNR(root, values);
        TreeNode ans = null;
        foreach (int val in values)
        {
            ans = Insert(ans, val);
        }

        return ans;
    }

    Dictionary<int, int> height = [];

    void LNR(TreeNode root, List<int> values)
    {
        if (root is null) return;
        LNR(root.left, values);
        values.Add(root.val);
        LNR(root.right, values);
    }

    void UpdateHeight(TreeNode x)
    {
        int left = 0, right = 0;
        if (x.left is not null)
        {
            left = height.GetValueOrDefault(x.left.val, 0);
        }
        if (x.right is not null)
        {
            right = height.GetValueOrDefault(x.right.val, 0);
        }

        height[x.val] = 1 + Math.Max(left, right);
    }

    int Balance(TreeNode x)
    {
        int left = 0, right = 0;
        if (x.left is not null)
        {
            left = height.GetValueOrDefault(x.left.val, 0);
        }
        if (x.right is not null)
        {
            right = height.GetValueOrDefault(x.right.val, 0);
        }

        return left - right;
    }

    /*
             y               x
            / \             / \
           x   T3   ->     T1  y
          / \                 / \
         T1 T2               T2 T3
    */

    TreeNode RotateRight(TreeNode y)
    {
        TreeNode x = y.left;
        TreeNode t2 = x.right;
        x.right = y;
        y.left = t2;
        UpdateHeight(y);
        UpdateHeight(x);
        return x;
    }

    /*
             x               y
            / \             / \
           T1  y   ->      x   T3
              / \        / \
             T2 T3      T1 T2
    */

    TreeNode RotateLeft(TreeNode x)
    {
        TreeNode y = x.right;
        TreeNode t2 = y.left;

        y.left = x;
        x.right = t2;
        UpdateHeight(x);
        UpdateHeight(y);
        return y;
    }

    TreeNode ReBalance(TreeNode root)
    {
        UpdateHeight(root);

        int balance = Balance(root);

        // left heavy
        if (balance > 1)
        {
            if (Balance(root.left) < 0) // LR case
            {
                root.left = RotateLeft(root.left);
            }
            else
            {
                return RotateRight(root); // LL case
            }
        }

        // right heavy
        if (balance < -1)
        {
            if (Balance(root.right) > 0) // RL case
            {
                root.right = RotateRight(root.right);
            }
            else
            {
                return RotateLeft(root); // RR case
            }
        }

        return root;
    }

    TreeNode Insert(TreeNode root, int val)
    {
        if (root is null)
        {
            height[val] = 1;
            return new(val);
        }

        if (root.val < val)
        {
            root.right = Insert(root.right, val);
        }
        else if (root.val > val)
        {
            root.left = Insert(root.left, val);
        }
        else
        {
            return root;
        }

        return ReBalance(root);
    }
}