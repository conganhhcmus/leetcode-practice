public class Solution
{
    public bool AsteroidsDestroyed(int mass, int[] asteroids)
    {
        int MAX = 100_001;
        int[] map = new int[MAX];
        int n = asteroids.Length;
        int max = 0;
        for (int i = 0; i < n; i++)
        {
            map[asteroids[i]]++;
            if (max < asteroids[i]) max = asteroids[i];
        }

        long sum = mass;
        for (int i = 0; i <= max; i++)
        {
            if (i > sum) return false;
            sum += 1L * i * map[i];
        }
        return true;
    }
}
