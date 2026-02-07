public class Solution
{
    public int[] MinOperations(string boxes)
    {

        // solution 1
        // int n = boxes.Length;
        // int[] prefixCount = new int[n + 1];
        // int[] res = new int[n];
        // int total = 0;
        // for (int i = 0; i < n; i++)
        // {
        //     prefixCount[i + 1] = prefixCount[i] + (boxes[i] - '0');
        //     total += (boxes[i] - '0') * i;
        // }

        // res[0] = total;
        // for (int i = 1; i < n; i++)
        // {
        //     res[i] = res[i - 1] + prefixCount[i] - (prefixCount[n] - prefixCount[i]);
        // }
        // return res;

        // solution 2
        int n = boxes.Length;
        int[] res = new int[n];
        int move = 0, count = 0;
        for (int i = 0; i < n; i++)
        {
            res[i] += move;
            count += boxes[i] - '0';
            move += count;
        }
        move = 0; count = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            res[i] += move;
            count += boxes[i] - '0';
            move += count;
        }

        return res;
    }
}