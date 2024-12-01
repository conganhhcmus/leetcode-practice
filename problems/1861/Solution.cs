namespace Problem_1861;

using Helpers;
using Structures;
public class Solution
{
    public static void Execute()
    {
        char[][] box = [
            ['#','#','*','.','*','.'],
            ['#','#','#','*','.','.'],
            ['#','#','#','.','#','.']
        ];
        var solution = new Solution();
        ArrayHelper.Print2DArray(solution.RotateTheBox(box));
    }
    public char[][] RotateTheBox(char[][] box)
    {
        int m = box.Length;
        int n = box[0].Length;
        char[][] rotatedBox = new char[n][];
        for (int j = 0; j < n; j++)
        {
            rotatedBox[j] = new char[m];
        }

        // rotate 90 degrees
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                rotatedBox[i][j] = box[m - 1 - j][i];
            }
        }

        // fall down
        for (int j = 0; j < m; j++)
        {
            for (int i = n - 1; i >= 0; i--)
            {
                if (rotatedBox[i][j] == '#')
                {
                    int saved = i;
                    while (saved + 1 < n && rotatedBox[saved + 1][j] == '.')
                    {
                        saved++;
                    }
                    (rotatedBox[i][j], rotatedBox[saved][j]) = (rotatedBox[saved][j], rotatedBox[i][j]);
                }
            }
        }

        return rotatedBox;
    }
}