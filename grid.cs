namespace Mazes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ImageSharp.Drawing.Pens;
    using System.Numerics;
    using ImageSharp;
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

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendLine($"+{String.Concat(Enumerable.Repeat("---+",(int)Columns))}");

            foreach(IEnumerable<Cell> row in EachRow())
            {
                var top = new StringBuilder("|");
                var bottom = new StringBuilder("+");

                foreach(Cell cell in row)
                {
                    var cellToWorkWith = cell ?? new Cell(0,0); // TODO: must be able to set to -1 afterall..

                    var body = String.Concat(Enumerable.Repeat(" ",3));
                    var eastBoundary = cellToWorkWith.IsLinked(cellToWorkWith.East) ? " " : "|";
                    top.Append($"{body}{eastBoundary}");

                    var southBoundary = cellToWorkWith.IsLinked(cellToWorkWith.South) ? "   " : "---";
                    var corner = "+";
                    bottom.Append($"{southBoundary}{corner}");
                }

                output.AppendLine(top.ToString());
                output.AppendLine(bottom.ToString());
            }

            return output.ToString();
        }

        public Image ToImage(uint cellSize = 50)
        {
            var imgWidth = cellSize * Columns;
            var imgHeight = cellSize * Rows;

            var image = new Image((int)imgWidth+1,(int)imgHeight+1);
            image.BackgroundColor(Color.White);

            var wall = Pens.Solid(Color.Black,(float)0.1);
        
            foreach(Cell cell in EachCell())
            {
                float x1 = cell.Column * cellSize;
                float y1 = cell.Row * cellSize;
                float x2 = (cell.Column+1) * cellSize;
                float y2 = (cell.Row+1) * cellSize;

                if(cell.North==null) image.DrawLines(wall,new Vector2[] {new Vector2(x1,y1),new Vector2(x2,y1)});
                if(cell.West==null) image.DrawLines(wall,new Vector2[] {new Vector2(x1,y1),new Vector2(x1,y2)});

                if(!cell.IsLinked(cell.East)) image.DrawLines(wall,new Vector2[] {new Vector2(x2,y1),new Vector2(x2,y2)});
                if(!cell.IsLinked(cell.South)) image.DrawLines(wall,new Vector2[] {new Vector2(x1,y2),new Vector2(x2,y2)});
            }
            return image;                
        }
    }
}