using BenchmarkDotNet.Attributes;
using Lab1;

namespace Benchmark;

[MemoryDiagnoser]
public class LongestOddPathBenchmark
{
    private readonly BinaryTree tree40 = BinaryTreeGenerator.FromTextFile(@"..\..\..\..\tree10.txt");
    private readonly BinaryTree tree1023 = BinaryTreeGenerator.FromTextFile(@"..\..\..\..\tree1k.txt");
    private readonly BinaryTree tree200k = BinaryTreeGenerator.FromTextFile(@"..\..\..\..\tree200k.txt");
    private readonly BinaryTree tree1M = BinaryTreeGenerator.FromTextFile(@"..\..\..\..\tree1M.txt");

    [Benchmark]
    public void LOP10NodesWithTreeCreation()
    {
        BinaryTree tree40 = BinaryTreeGenerator.FromTextFile(@"..\..\..\..\tree10.txt");
        tree40.LongestOddPath();
    }

    [Benchmark]
    public void LOP1kNodesWithTreeCreation()
    {
        BinaryTree tree1023 = BinaryTreeGenerator.FromTextFile(@"..\..\..\..\tree1k.txt");
        tree1023.LongestOddPath();
    }

    [Benchmark]
    public void LOP200kNodesWithTreeCreation()
    {
        BinaryTree tree200K = BinaryTreeGenerator.FromTextFile(@"..\..\..\..\tree200k.txt");
        tree200K.LongestOddPath();
    }

    [Benchmark]
    public void LOP1MNodesWithTreeCreation()
    {
        BinaryTree tree1M = BinaryTreeGenerator.FromTextFile(@"..\..\..\..\tree1M.txt");
        tree1M.LongestOddPath();
    }


    [Benchmark]
    public void LOP10Nodes()
    {
        tree40.LongestOddPath();
    }

    [Benchmark]
    public void LOP1kNodes()
    {
        tree1023.LongestOddPath();
    }

    [Benchmark]
    public void LOP200kNodes()
    {
        tree200k.LongestOddPath();
    }

    [Benchmark]
    public void LOP1MNodes()
    {
        tree1M.LongestOddPath();
    }
}

