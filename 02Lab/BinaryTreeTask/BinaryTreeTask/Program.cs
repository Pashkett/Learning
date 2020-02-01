using System;

namespace BinaryTreeTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Binary tree:");
            StudentScore ss = new StudentScore()
            {
                StudentName = "Ivan",
                Score = 98,
                TestName = "Math",
                TestDate = DateTime.Now
            };
            StudentScore ss1 = new StudentScore()
            {
                StudentName = "Artem",
                Score = 99,
                TestName = "Math",
                TestDate = DateTime.Now
            };

            Console.WriteLine(ss.ToString());

            BinaryTree<StudentScore> binaryTree = new BinaryTree<StudentScore>();
            binaryTree.AddingElement += Console.WriteLine;
            binaryTree.InsertNode(ss);
            binaryTree.InsertNode(ss1);
        }
    }
}
