namespace ConsoleApplication
{
    using Mazes;
    using System.IO;
    using ImageSharp;
    public class Program
    {
        public static void Main(string[] args)
        {
            Grid binaryTreeGrid = new Grid(4,4);
            BinaryTree.Perform(binaryTreeGrid);
            System.Console.Write($"BinaryTree\n{binaryTreeGrid.ToString()}");
            using(FileStream output = File.OpenWrite("maze_binarytree_csharp.png"))
            {
                binaryTreeGrid.ToImage().SaveAsPng(output);
            }

            Grid sideWinderGrid = new Grid(4,4);
            SideWinder.Perform(sideWinderGrid);
            System.Console.WriteLine($"SideWinder\n{sideWinderGrid.ToString()}");
            
            using(FileStream output = File.OpenWrite("maze_sidewinder_csharp.png"))
            {
                sideWinderGrid.ToImage().SaveAsPng(output);
            }

            DistanceGrid sideWinderDistanceGrid = new DistanceGrid(5,5);
            SideWinder.Perform(sideWinderDistanceGrid);

            sideWinderDistanceGrid.Distance = sideWinderDistanceGrid[0,0].GetDistances().PathTo(sideWinderDistanceGrid[sideWinderDistanceGrid.Rows-1,0]);
            System.Console.WriteLine($"SideWinder DistanceGrid\n{sideWinderDistanceGrid.ToString()}");
        }
    }
}
