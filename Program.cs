using System;
using CircularArrayImplementation.DataStructures;

namespace CircularArrayImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            CircularArray<int> circularArray = new CircularArray<int>();

            // Start from here to use circularArray
            // Test test = new Test
            // {
            //     Id = 1,
            //     Name = "Test1"
            // };
            // Test test1 = new Test
            // {
            //     Id = 2,
            //     Name = "Test2"
            // };
            // Test test2 = new Test
            // {
            //     Id = 3,
            //     Name = "Test3"
            // };

            circularArray.AddRange(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);

            System.Console.WriteLine(circularArray[200]);
            circularArray.RemoveItem(200);
            circularArray.JugglingRotate(3);

            foreach (int item in circularArray)
            {
                System.Console.Write(item + " ");
            }

        }
    }
}
