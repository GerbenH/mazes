namespace ConsoleApplication
{
    using Mazes;
    public class Program
    {
        public static void Main(string[] args)
        {
            Grid binaryTreeGrid = new Grid(4,4);
            BinaryTree.Perform(binaryTreeGrid);
            System.Console.Write($"BinaryTree\n{binaryTreeGrid.ToString()}");

            Grid sideWinderGrid = new Grid(4,4);
            SideWinder.Perform(sideWinderGrid);
            System.Console.WriteLine($"SideWinder\n{sideWinderGrid.ToString()}");
        }
    }
}
