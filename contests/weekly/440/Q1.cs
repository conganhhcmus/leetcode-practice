#if DEBUG
namespace Weekly_440_Q1;
#endif

public class Solution
{
    public int NumOfUnplacedFruits(int[] fruits, int[] baskets)
    {
        int n = fruits.Length;
        bool[] visited = new bool[n];
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            int find = FindAvaliableBasket(baskets, visited, fruits[i]);
            if (find == -1) count++;
            else visited[find] = true;
        }
        return count;
    }

    int FindAvaliableBasket(int[] backets, bool[] visited, int quantity)
    {
        int n = backets.Length;
        for (int i = 0; i < n; i++)
        {
            if (visited[i]) continue;
            if (backets[i] < quantity) continue;
            return i;
        }
        return -1;
    }
}