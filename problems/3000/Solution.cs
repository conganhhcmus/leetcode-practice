#if DEBUG
namespace Problems_3000;
#endif

public class Solution
{
    public int AreaOfMaxDiagonal(int[][] dimensions)
    {
        int maxArea = 0;
        int maxDiaSq = 0;
        foreach (int[] dimension in dimensions)
        {
            int h = dimension[0], w = dimension[1];
            int diaSq = h * h + w * w;
            int area = h * w;

            if (diaSq > maxDiaSq || (diaSq == maxDiaSq && area > maxArea))
            {
                maxArea = area;
                maxDiaSq = diaSq;
            }
        }
        return maxArea;
    }
}