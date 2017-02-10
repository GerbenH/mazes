namespace Mazes
{
    using System;
    public class DistanceGrid : Grid
    {
        private Distances _distances;

        public DistanceGrid(uint rows,uint columns)
            : base(rows, columns)
        {}
        
        protected override string ContentsOf(Cell cell)
        {
            if(_distances?[cell] != null)
            {
                return $" {_distances[cell]} ";
            }else
            {
                return base.ContentsOf(cell);
            }
        }

        public Distances Distance
        {
            set { _distances = value;}
        }

    }
}