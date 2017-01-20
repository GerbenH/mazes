namespace Mazes
{
    using System.Linq;
    using System.Collections.Generic;
    public class Cell
    {
        private readonly Dictionary<Cell,bool> links = new Dictionary<Cell,bool>();

        public uint Row { get; }
        public uint Column { get; }
        public Cell North { get; set; }
        public Cell South { get; set; }
        public Cell East { get; set; }
        public Cell West { get; set; }

        public Cell(uint row, uint column) { Row = row; Column = column;}

        public Cell Link(Cell linkingCell,bool bidi = true)
        {
            links[linkingCell]=true;
            if(bidi) linkingCell.Link(this,true);
            return this;
        }

        public Cell Unlink(Cell unlinkingCell,bool bidi=true)
        {
            links.Remove(unlinkingCell);
            if(bidi) unlinkingCell.Unlink(this,false);
            return this;
        }

        public List<Cell> GetAllLinks
        {
            get { return links.Keys.ToList(); }
        }

        public bool IsLinked(Cell neighbourCells)
        {
            try { return links[neighbourCells]; }
            catch(KeyNotFoundException) { return false; }
        }

        public List<Cell> Neighbours
        {
            get
            {
                List<Cell> returnList = new List<Cell>();
                if(North!=null) returnList.Add(North);
                if(South!=null) returnList.Add(South);
                if(East!=null) returnList.Add(East);
                if(West!=null) returnList.Add(West);
                return returnList;
            }
        }
    }
}