namespace Mazes
{
    using System.Collections.Generic;
    using System.Linq;
    public class Distances
    {
        private readonly Cell RootCell;
        private readonly Dictionary<Cell,int> cells;
        public Distances(Cell Root)
        {   
            RootCell = Root;
            cells = new Dictionary<Cell,int>();
            cells[Root] = 0;
        }

        public int? this[Cell cell]
        {
            get { if(cells.ContainsKey(cell)) return cells[cell]; else return null; }
            set { cells[cell] = value.Value; }
        }

        public List<Cell> Cells
        {
            get { return cells.Keys.ToList(); }
        }

        public Distances PathTo(Cell Goal)
        {
            Cell current = Goal;

            Distances breadCrumbs = new Distances(RootCell);
            breadCrumbs[current] = cells[current];

            while(current != RootCell)
            {
                foreach(Cell linked_cell in current.GetAllLinks)
                {
                    if(cells[linked_cell] < cells[current])
                    {
                        breadCrumbs[linked_cell] = cells[linked_cell];
                        current = linked_cell;
                        break;
                    }
                }
            }
            return breadCrumbs;
        } 
    }
}