using System;

namespace ConsoleApplication
{
    using Mazes;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main(string[] args)
        {
            Grid myGrid = new Grid(4,4);
            BinaryTree.Perform(myGrid);
        }
    }
}
