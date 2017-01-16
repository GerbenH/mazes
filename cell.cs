namespace Mazes
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Cell
    {
        private readonly Dictionary<string,bool> links = new Dictionary<string,bool>();

        public Cell(uint row,uint column)
        {
            Row = row;
            Column = column;
            Key = System.Guid.NewGuid().ToString();
        }

        public string Key
        {
            get;
        }

        public uint Row
        {
            get;
        }

        public uint Column
        {
            get;
        }

        public Cell North
        {
            get;
            set;
        }

        public Cell South
        {
            get;
            set;
        }

        public Cell East
        {
            get;
            set;
        }

        public Cell West
        {
            get;
            set;
        }

        public Cell Link(Cell linkingCell,bool bidi = true)
        {
            links[linkingCell.Key]=true;
            if(bidi)
            {
                linkingCell.Link(this,true);
            }
            return this;
        }

        public Cell Unlink(Cell unlinkingCell,bool bidi=true)
        {
            links.Remove(unlinkingCell.Key);
            if(bidi)
            {
                unlinkingCell.Unlink(this,false);
            }
            return this;
        }

        public List<string> GetAllLinks
        {
            get
            {
                return links.Keys.ToList();
            }
        }

        public bool IsLinked(Cell neighbourCells)
        {
            try
            {
                return links[neighbourCells.Key];
            }
            catch(KeyNotFoundException)
            {
                return false;
            }
        }

        public List<Cell> Neighbours
        {
            get
            {
                List<Cell> returnList = new List<Cell>
                {
                    North,
                    South,
                    West,
                    East
                };
                return returnList.FindAll(c => c != null);
            }
        }
    }
}