using System;
using CircularArrayImplementation.DataStructures;

namespace CircularArrayImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            CircularArray<Test> circularArray = new CircularArray<Test>();

            // Start from here to use circularArray
            Test test = new Test
            {
                Id = 1,
                Name = "Test1"
            };
            Test test1 = new Test
            {
                Id = 2,
                Name = "Test2"
            };
            Test test2 = new Test
            {
                Id = 3,
                Name = "Test3"
            };

            circularArray.AddRange(new Test[] { test, test1, test2 });

            //circularArray.ReversalRotate(2);
            foreach (Test item in circularArray)
            {
                System.Console.WriteLine(item.Name);
            }

            for (int i = 0; i < circularArray.Length; i++)
            {
                System.Console.WriteLine(circularArray[i].Name);
            }
        }
    }
}
