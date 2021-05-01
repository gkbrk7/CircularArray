using System;
using CircularArrayImplementation.DataStructures;

namespace CircularArrayImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CircularArray<string> circularArray = new CircularArray<string>();
            circularArray.AddRange(new string[] { "1", "2", "3", "4" });
            circularArray.AddRange(new string[] { "5", "6" });
            circularArray.AddItem("7");

            foreach (var item in circularArray)
            {
                System.Console.Write(item + " ");
            }
            System.Console.WriteLine();
            //circularArray.ListByIndex(1);
            circularArray.ReversalRotate(2);

            // System.Console.WriteLine(circularArray.Length);
            foreach (var item in circularArray)
            {
                System.Console.Write(item + " ");
            }

            // circularArray.LeftRotate(1);
            // System.Console.WriteLine();

            // foreach (var item in circularArray)
            // {
            //     System.Console.Write(item + " ");
            // }

            // circularArray.RightRotate(1);
            // System.Console.WriteLine();

            // foreach (var item in circularArray)
            // {
            //     System.Console.Write(item + " ");
            // }
        }
    }
}
