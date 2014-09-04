using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonGenerator
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    //Path

    //Eval strategy
    /*
     * Can we get from start to finish? (Path)
     * How many rooms can the player beat? (Challenge level)
     * How much of the run is unchallenging? (Rooms where the player is not challenged)
     * (Treasure)
     */

    //Genotype
    public class Dungeon
    {
        public readonly List<Room> rooms;
        
        public readonly Room Entrance;

        public readonly Room Exit;

        public readonly List<Connection> Connections;

        public Dungeon(List<Room> rooms, List<Connection> roomConnections, Room entrance, Room exit)
        {
            this.rooms = rooms;
            this.Entrance = entrance;
            this.Exit = exit;
            this.Connections = roomConnections;
        }




    }

    public class Connection
    {
        public Room oneRoom;
        public Room otherRoom;

        public Room getOtherRoom(Room r)
        {
            if (r == oneRoom) return otherRoom;
            if (r == otherRoom) return oneRoom;
            return null;
        }

        public bool containsRoom(Room r)
        {
            if (r == oneRoom || r == otherRoom) return true;
            return false;
        }
    }

    public class Room
    {
        List<Enemy> enemies = new List<Enemy>(); 
        //List<Treasure> loot = new List<Treasure>();
        private int sizeX, sizeY;
    }

    internal enum Enemy
    {
        Rat = 1, Goblin = 3, Wolf = 4, Orc = 6, Bear = 8, Ogre = 18, Dragon = 30  
    }
}
