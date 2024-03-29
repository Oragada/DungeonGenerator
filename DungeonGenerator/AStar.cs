﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DungeonGenerator
{




//}
/// Original AStar Java implementation by Julian Togelius, 9/5/12
/// Ported to C# by Christian Jensen, chrj@itu.dk
    class AStar
    {
        public static int Distance(bool[][] passable, int startX, int startY, int goalX, int goalY)
        {
            int[][] distanceMatrix = new int[passable.Length][];
            for (int i = 0; i < passable[0].Length; i++)
            {
                distanceMatrix[i] = new int[passable[i].Length];
            }
            for (int i = 0; i < distanceMatrix.Length; i++)
            {
                for (int j = 0; j < distanceMatrix[i].Length; j++)
                {
                    distanceMatrix[i][j] = -1;
                }
            }
            distanceMatrix[startX][startY] = 0;
            SortedList<Node> openSet = new SortedList<Node>();
            Node initial = new Node(startX, startY, 0, euclideanDistance(startX, startY, goalX, goalY));
            openSet.Add(initial);



            return 0;
        }
    }

//    public static int distance (boolean[][] passable, int startX, int startY, int goalX, int goalY) {
//        int[][] distanceMatrix = new int[passable.length][passable[0].length];
//        for (int i = 0; i < distanceMatrix.length; i++) {
//            for (int j = 0; j < distanceMatrix[0].length; j++) {
//                distanceMatrix[i][j] = -1;
//            }
//        }
//        distanceMatrix[startX][startY] = 0;
//        PriorityQueue<Node> openSet = new PriorityQueue<Node> ();
//        Node initial = new Node (startX, startY, 0, euclideanDistance (startX, startY, goalX, goalY));
//        openSet.add (initial);
//        while (true) {
//            if (openSet.isEmpty()) {
//                // we failed to find the goal
//                return -1;
//            }
//            Node current = openSet.poll ();
//            if (current.x == goalX && current.y == goalY) {
//                // we found it!
//                return current.costToGetHere;
//            }
//            // search all the neighbours
//            List<Node> neighbours = current.generateNeighbours (passable, distanceMatrix, goalX, goalY);
//            openSet.addAll(neighbours);
//        }
//    }

//    public static int euclideanDistance(int x1, int y1, int x2, int y2) {
//        return (int) Math.sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
//    }

//    public static boolean exists(int x, int y, boolean[][] passable) {
//        return x >= 0 && y >= 0 && x < passable.length && y < passable[0].length;
//    }


//    public static void main(String[] args) {
//        boolean[][] testmap = {
//                {true , true , false, true , true , true },
//                {false, true , false, true , true , false},
//                {true , true , false, false, true , true },
//                {false, true , true , true , true , false},
//                {false, false, false, false, true , false},
//                {true , true , true , true , true , true },

//        };
//        System.out.println(distance(testmap, 0, 0, 5, 5));
//    }
    internal class Node
    {
        private int x;
        private int y;
        private int costToGetHere;
        private int estimatedCostToGoal;

        public Node(int x, int y, int costToGetHere, int estimatedCostToGoal)
        {
            this.x = x;
            this.y = y;
            this.costToGetHere = costToGetHere;
            this.estimatedCostToGoal = estimatedCostToGoal;
        }

        public int Total
        {
            get { return costToGetHere + estimatedCostToGoal; }
        }

        public List<Node> generateNeighbours(bool[][] passable, int[][] distanceMatrix, int goalX, int goalY)
        {
            LinkedList<Node> list = new LinkedList<Node>();
            CreateAndAdd(x + 1, y, goalX, goalY, passable, distanceMatrix, list);
            CreateAndAdd(x - 1, y, goalX, goalY, passable, distanceMatrix, list);
            CreateAndAdd(x, y + 1, goalX, goalY, passable, distanceMatrix, list);
            CreateAndAdd(x, y - 1, goalX, goalY, passable, distanceMatrix, list);
            return list.ToList();
        }

        public void CreateAndAdd(int newX, int newY, int goalX, int goalY, bool[][] passable, int[][] distanceMatrix,
            List<Node> list)
        {
            
        } 
}

//        private void createAndAdd (int newX, int newY, int goalX, int goalY, boolean[][] passable,
//                                   int[][] distanceMatrix, List<Node> list) {
//            if (exists (newX, newY, passable) && passable[newX][newY]) {
//                int newCost = this.costToGetHere + 1;
//                int newEstimate = euclideanDistance (newX, newY, goalX, goalY);
//                Node newNode = new Node (newX, newY, newCost, newEstimate);
//                if (distanceMatrix[newX][newY] < 0 || newCost < distanceMatrix[newX][newY]) {
//                   // if (newX == goalX && newY == goalY)
//                   //     System.out.println("adding goal " + newX + " " + newY + " " + newCost);
//                    list.add (newNode);
//                    distanceMatrix[newX][newY] = newCost;
//                }
//            }
//        }
//    }
    
}

