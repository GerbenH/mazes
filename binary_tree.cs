namespace Mazes
{
    using System.Collections.Generic;
    using System;
    public class BinaryTree
    {
        private static Random rand = new Random();
        public static void Perform(Grid grid)
        {
            Cell neighbor;
            foreach(Cell cell in grid.EachCell())
            {
                List<Cell> neighbors = new List<Cell>();
                if(cell.North!=null) neighbors.Add(cell.North);
                if(cell.East!=null) neighbors.Add(cell.East);
                try { neighbor = neighbors[rand.Next(neighbors.Count)]; }
                catch { neighbor = null; }
                if(neighbor!=null) cell.Link(neighbor);
            }
        }
    }
}