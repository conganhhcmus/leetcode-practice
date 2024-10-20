namespace Problem_841;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        IList<IList<int>> rooms = [[1, 3], [3, 0, 1], [2], [0]];
        Console.WriteLine(solution.CanVisitAllRooms(rooms));
    }
    public bool CanVisitAllRooms(IList<IList<int>> rooms)
    {
        HashSet<int> roomMap = [];
        HashSet<int> keys = [];

        void DFS(IList<IList<int>> rooms, int roomIndex)
        {
            if (roomMap.Contains(roomIndex)) return;
            if (roomIndex == 0 || keys.Contains(roomIndex))
            {
                roomMap.Add(roomIndex);
                keys.UnionWith(rooms[roomIndex]);
                foreach (int neighbor in rooms[roomIndex])
                {
                    DFS(rooms, neighbor);
                }
            }
        }

        DFS(rooms, 0);

        return roomMap.Count == rooms.Count;
    }
}