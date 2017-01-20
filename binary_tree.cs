namespace Mazes
{
    using System.Collections.Generic;
    using System;
    public class BinaryTree
    {
        private static Random rand = new Random();
        public static void Perform(Grid grid)
        {
            foreach(Cell cell in grid.EachCell())
            {
                List<Cell> neighbors = new List<Cell>();
                if(cell.North!=null) neighbors.Add(cell.North);
                if(cell.East!=null) neighbors.Add(cell.East);
                Cell neighbor = neighbors[rand.Next(neighbors.Count)];
                if(neighbor!=null) cell.Link(neighbor);
            }
        }
    }
}