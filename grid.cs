namespace Mazes
{
    using System;
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
    }
}