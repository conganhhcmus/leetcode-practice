public class Solution
{
    public int LargestRectangleArea(int[] heights)
    {
        int n = heights.Length;
        int max = 0;
        Stack<(int w, int h)> stack = [];
        int tmpW, tmpH;
        for (int i = 0; i < n; i++)
        {
            tmpW = 0;
            tmpH = int.MaxValue;
            max = Math.Max(max, heights[i]);
            while (stack.Count > 0 && stack.Peek().h >= heights[i])
            {
                var (w, h) = stack.Pop();
                tmpW += w;
                tmpH = Math.Min(tmpH, h);
                max = Math.Max(max, tmpW * tmpH);
            }
            stack.Push((tmpW, tmpH));
            stack.Push((1, heights[i]));
        }
        tmpW = 0;
        tmpH = int.MaxValue;
        while (stack.Count > 0)
        {
            var (w, h) = stack.Pop();
            tmpW += w;
            tmpH = Math.Min(tmpH, h);
            max = Math.Max(max, tmpW * tmpH);
        }

        return max;
    }
}