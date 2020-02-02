using System;

namespace BinaryTreeTask
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<StudentScore> binaryTree = new BinaryTree<StudentScore>();
            binaryTree.AddingElement += Console.WriteLine;
            binaryTree.TreeClearing += Console.WriteLine;

            bool toContinue = true;
            while (toContinue)
            {
                Console.WriteLine("Please add student scores [Student Name], [Test Name] and [Score].");

                Console.Write("Student Name: ");
                string name = Console.ReadLine();

                Console.Write("\nTest Name: ");
                string testName = Console.ReadLine();

                Console.Write("\nScore: ");
                string score = Console.ReadLine();
                if (int.TryParse(score, out int scoreint))
                    binaryTree.InsertNode(new StudentScore() 
                        { 
                            StudentName = name, 
                            TestName = testName, 
                            Score = scoreint }
                    );

                Console.WriteLine("To Continue press Y, to exit other");
                string resolution = Console.ReadLine();

                if (resolution.ToUpper() == "Y")
                    toContinue = true;
                else
                    toContinue = false;
            }
        }
    }
}
 