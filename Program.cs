namespace ConsoleApplication
{
    using Mazes;
    public class Program
    {
        public static void Main(string[] args)
        {
            Grid myGrid = new Grid(4,4);
            BinaryTree.Perform(myGrid);
            System.Console.Write(myGrid.ToString());
        }
    }
}
