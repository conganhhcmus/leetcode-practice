public class Solution
{
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