namespace Mazes
{
    using System;
    using System.Collections.Generic;
    public class SideWinder
    {
        private static Random random = new Random();
        public static void Perform(Grid grid)
        {
            foreach(IEnumerable<Cell> row in grid.EachRow())
            {
                var run = new List<Cell>();
                foreach(Cell cell in row)
                {
                    run.Add(cell);

                    var atEasternBoundary = cell.East==null;
                    var atNorthernBoundary = cell.North==null;

                    var shouldCloseOut = atEasternBoundary ||
                        (!atNorthernBoundary && (random.Next(2)==0));
                    
                    if(shouldCloseOut)
                    {
                        var member = run[random.Next(run.Count)];
                        if(member.North!=null) member.Link(member.North);
                        run.Clear();
                    }else
                    {
                        cell.Link(cell.East);
                    }
                }
            }
        }
    }
}