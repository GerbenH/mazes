namespace Mazes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Grid
    {
        private Cell[,] grid;

        public uint Rows { get; }
        public uint Columns { get; }

        public Grid(uint rows, uint columns) { Rows = rows; Columns = columns; PrepareGrid(); ConfigureCells(); }

        private void PrepareGrid()
        {
            grid = new Cell[Rows,Columns];
            for(uint i=0;i<grid.GetLength(0);i++)
                for(uint j=0;j<grid.GetLength(1);j++)
                     grid[i,j] = new Cell(i,j);
        }

        private void ConfigureCells()
        {
            foreach(Cell cell in grid)
            {
                cell.North = this[cell.Row-1,cell.Column];
                cell.South = this[cell.Row+1,cell.Column];
                cell.West = this[cell.Row,cell.Column-1];
                cell.East = this[cell.Row,cell.Column+1];
            }
        }

        public Cell this[uint Row,uint Column]
        {
            get
            {
                if(Row >= Rows) return null;
                if(Column >= Columns) return null;
                return grid[Row,Column]; 
            }
        }

        public Cell RandomCell()
        {
            Random rand = new Random();
            uint randomRow = (uint)rand.Next((int)Rows);
            uint randomColumn = (uint)rand.Next((int)Columns);
            return this[randomRow,randomColumn];
        }

        public uint Size
        {
            get { return Rows * Columns; }
        }

        public IEnumerable<IEnumerable<Cell>> EachRow()
        {
            for(uint row = 0;row<Rows;row++)
                yield return grid.Cast<Cell>().Skip((int)(row*Columns)).Take((int)Columns);         
        }

        public IEnumerable<Cell> EachCell()
        {
            return grid.Cast<Cell>();
        }
    }
}