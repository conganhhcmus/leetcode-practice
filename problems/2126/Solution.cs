public class Solution
{
    public bool AsteroidsDestroyed(int mass, int[] asteroids)
    {
        int MAX = 100_001;
        int n = asteroids.Length;
        Array.Sort(asteroids);
        for (int i = 0; i < n; i++)
        {
            if (mass < asteroids[i]) return false;
            mass += asteroids[i];
            if (mass > MAX) mass = MAX;
        }
        return true;
    }
}
