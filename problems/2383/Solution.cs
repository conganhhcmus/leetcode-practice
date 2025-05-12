#if DEBUG
namespace Problems_2383;
#endif

public class Solution
{
    public int MinNumberOfHours(int initialEnergy, int initialExperience, int[] energy, int[] experience)
    {
        int n = energy.Length;
        int needEnergy = 1;
        int needExperience = 0;
        for (int i = 0; i < n; i++)
        {
            needEnergy += energy[i];
            if (initialExperience <= experience[i])
            {
                needExperience += experience[i] - initialExperience + 1;
                initialExperience = experience[i] + 1;
            }
            initialExperience += experience[i];
        }
        return Math.Max(0, needEnergy - initialEnergy) + needExperience;
    }
}