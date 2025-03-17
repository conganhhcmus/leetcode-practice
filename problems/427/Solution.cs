#if DEBUG
namespace Problems_427;
#endif

// Definition for a QuadTree node.
public class Node
{
    public bool val;
    public bool isLeaf;
    public Node topLeft;
    public Node topRight;
    public Node bottomLeft;
    public Node bottomRight;

    public Node()
    {
        val = false;
        isLeaf = false;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }

    public Node(bool _val, bool _isLeaf)
    {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }

    public Node(bool _val, bool _isLeaf, Node _topLeft, Node _topRight, Node _bottomLeft, Node _bottomRight)
    {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = _topLeft;
        topRight = _topRight;
        bottomLeft = _bottomLeft;
        bottomRight = _bottomRight;
    }
}

public class Solution
{
    public Node Construct(int[][] grid)
    {
        int n = grid.Length;
        return ConstructHelper(grid, 0, 0, n);
    }

    private Node ConstructHelper(int[][] grid, int rowStart, int colStart, int len)
    {
        if (len <= 1)
        {
            return new Node(grid[rowStart][colStart] == 1, true);
        }

        Node node = new Node();
        int mid = len / 2;
        node.topLeft = ConstructHelper(grid, rowStart, colStart, mid);
        node.topRight = ConstructHelper(grid, rowStart, colStart + mid, mid);
        node.bottomLeft = ConstructHelper(grid, rowStart + mid, colStart, mid);
        node.bottomRight = ConstructHelper(grid, rowStart + mid, colStart + mid, mid);

        bool allLeaf = node.bottomLeft.isLeaf && node.bottomRight.isLeaf && node.topLeft.isLeaf && node.topRight.isLeaf;
        bool sameVal = node.bottomLeft.val == node.bottomRight.val && node.bottomLeft.val == node.topLeft.val && node.bottomLeft.val == node.topRight.val;

        node.isLeaf = allLeaf && sameVal;
        node.val = node.bottomLeft.val;
        if (node.isLeaf)
        {
            return new Node(node.val, node.isLeaf);
        }
        return node;
    }
}