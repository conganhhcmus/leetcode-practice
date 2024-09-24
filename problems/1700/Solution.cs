namespace Problem_1700;

public class Solution
{
    public static void Execute()
    {
        var students = new[] { 1, 1, 0, 0 };
        var sandwiches = new[] { 0, 1, 0, 1 };

        var solution = new Solution();
        Console.WriteLine(solution.CountStudents(students, sandwiches));
    }
    public int CountStudents(int[] students, int[] sandwiches)
    {
        var index = 0;
        var temp = students.ToList();
        var count = 0;
        while (count < temp.Count)
        {
            if (temp[0] == sandwiches[index])
            {
                count = 0;
                index++;
            }
            else
            {
                temp.Add(temp[0]);
                count++;
            }
            temp.RemoveAt(0);
        }

        return sandwiches.Length - index;
    }
}