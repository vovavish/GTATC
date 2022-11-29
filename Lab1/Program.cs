using Lab1;
using System.Diagnostics;

Stopwatch sw = Stopwatch.StartNew();

BinaryTree tree = BinaryTreeGenerator.FromTextFile(@"C:\Users\User\Desktop\tree40.txt");
tree.LongestOddPath();

sw.Stop();

Console.WriteLine(sw.ElapsedTicks);

Stopwatch sw2 = Stopwatch.StartNew();

BinaryTree tree2 = BinaryTreeGenerator.FromTextFile(@"C:\Users\User\Desktop\tree40.txt");
tree2.LongestOddPath();

sw2.Stop();

Console.WriteLine(sw2.ElapsedTicks);
//TreePrinter.Print(tree);


Console.WriteLine("\nLongest Odd Path:");

//for (int i = 0; i < longestPath.Count; i++)
//{
//    Console.Write(longestPath[i].Value);

//    if (i != longestPath.Count - 1)
//    {
//        Console.Write(", ");
//    }
//}

Console.WriteLine();
//Console.WriteLine(string.Join(", ", tree.ToArray()));