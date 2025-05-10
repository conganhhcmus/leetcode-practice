#if DEBUG
namespace Problems_2037;
#endif

public class Solution
{
    public int MinMovesToSeat(int[] seats, int[] students)
    {
        int n = seats.Length;
        Array.Sort(seats);
        Array.Sort(students);
        int ret = 0;
        for (int i = 0; i < n; i++)
        {
            ret += Math.Abs(students[i] - seats[i]);
        }

        return ret;
    }
}