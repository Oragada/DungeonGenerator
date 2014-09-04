using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DungeonGenerator
{
    public class Dijkstra
    {
        public static bool Run(Dungeon dungeon)
        {
            Dictionary<Room, int> distanceMap = new Dictionary<Room, int>();
            Dictionary<Room, bool> visited = new Dictionary<Room, bool>();
            foreach (Room room in dungeon.rooms)
            {
                distanceMap.Add(room,int.MaxValue);
                visited.Add(room,false);
            }
            //Assume all rooms are unique
            //Assume all rooms cannot link to themselves
            //Assume all connections are unique
            distanceMap[dungeon.Entrance] = 0;
            Room current = dungeon.Entrance;
            while (true)
            {
                //get all neighbor rooms:
                //get connections from the current room,
                //then get the room at the other end
                //that is not on the visited list
                IEnumerable<Room> neighborRooms =
                    dungeon.Connections.Where(c => c.containsRoom(current))
                        .Select(e => e.getOtherRoom(current))
                        .Where(e => !visited[e]);
                foreach (Room neighborRoom in neighborRooms.Where(neighborRoom => distanceMap[current] + 1 < distanceMap[neighborRoom]))
                {
                    distanceMap[neighborRoom] = distanceMap[current] + 1;
                }

                visited[current] = true;
                if (visited[dungeon.Exit])
                {
                    return true;
                }
                //Does any room exists that is not visited and is neighbouring a visited room (has a tentative distance) 
                if (distanceMap.Any(e => distanceMap[e.Key] != int.MaxValue & !visited[e.Key]))
                {
                    return false;
                }
                current = distanceMap.First(e => e.Value == distanceMap.Min(f => f.Value) && !visited[e.Key]).Key;
            }
        }
    }
}