using BenchmarkDotNet.Attributes;
using Lab1;

namespace Benchmark;

[MemoryDiagnoser]
[RankColumn]
public class LongestOddPathBenchmark
{
    //private readonly BinaryTree tree40 = BinaryTreeGenerator.FromTextFile(@"C:\Users\User\Desktop\tree40.txt");
    //private readonly BinaryTree tree1023 = BinaryTreeGenerator.FromTextFile(@"C:\Users\User\Desktop\tree1023.txt");
    //private readonly BinaryTree tree200_000 = BinaryTreeGenerator.FromTextFile(@"C:\Users\User\Desktop\tree200000.txt");

    [Benchmark]
    public void LongestOddPath40Nodes()
    {
        BinaryTree tree40 = BinaryTreeGenerator.FromTextFile(@"C:\Users\User\Desktop\tree40.txt");
        tree40.LongestOddPath();
    }

    [Benchmark]
    public void LongestOddPath1023Nodes()
    {
        BinaryTree tree1023 = BinaryTreeGenerator.FromTextFile(@"C:\Users\User\Desktop\tree1023.txt");
        tree1023.LongestOddPath();
    }

    [Benchmark]
    public void LongestOddPath200000Nodes()
    {
        BinaryTree tree200_000 = BinaryTreeGenerator.FromTextFile(@"C:\Users\User\Desktop\tree200000.txt");
        tree200_000.LongestOddPath();
    }

    [Benchmark]
    public void LongestOddPath1MNodes()
    {
        BinaryTree tree1_000_000 = BinaryTreeGenerator.FromTextFile(@"C:\Users\User\Desktop\tree1M.txt");
        tree1_000_000.LongestOddPath();
    }

    [Benchmark]
    public void TEST()
    {
    }
}

