using BenchmarkDotNet.Attributes;

using Lab2;

namespace Benchmark;

[MemoryDiagnoser]
public class DelNearestLeafsToRootBenchmark
{
    private static readonly string tree15serialize = File.ReadAllText(@"..\..\..\..\tree15.txt");
    private static readonly string tree1kserialize = File.ReadAllText(@"..\..\..\..\tree1k.txt");
    private static readonly string tree260kserialize = File.ReadAllText(@"..\..\..\..\tree260k.txt");
    private static readonly string tree1Mserialize = File.ReadAllText(@"..\..\..\..\tree1M.txt");

    private readonly NAryTree tree15 = NAryTreeSerializer.Deserialize(tree15serialize);
    private readonly NAryTree tree1k = NAryTreeSerializer.Deserialize(tree1kserialize);
    private readonly NAryTree tree260k = NAryTreeSerializer.Deserialize(tree260kserialize);
    private readonly NAryTree tree1M = NAryTreeSerializer.Deserialize(tree1Mserialize);

    //[Benchmark]
    //public void RNL15NWithTreeDeserialize()
    //{
    //    NAryTree tree15 = NAryTreeSerializer.Deserialize(tree15serialize);
    //    tree15.RemoveNearestNodes();
    //}

    //[Benchmark]
    //public void RNL1kNWithTreeDeserialize()
    //{
    //    NAryTree tree1k = NAryTreeSerializer.Deserialize(tree1kserialize);
    //    tree1k.RemoveNearestNodes();
    //}

    //[Benchmark]
    //public void RNL260kNWithTreeDeserialize()
    //{
    //    NAryTree tree260k = NAryTreeSerializer.Deserialize(tree260kserialize);
    //    tree260k.RemoveNearestNodes();
    //}

    //[Benchmark]
    //public void RNL1MNWithTreeDeserialize()
    //{
    //    NAryTree tree1M = NAryTreeSerializer.Deserialize(tree1Mserialize);
    //    tree1M.RemoveNearestNodes();
    //}


    [Benchmark]
    public void RNL15Nodes()
    {
        tree15.RemoveNearestNodes();
    }

    [Benchmark]
    public void RNL1kNodes()
    {
        tree1k.RemoveNearestNodes();
    }

    [Benchmark]
    public void RNL260kNodes()
    {
        tree260k.RemoveNearestNodes();
    }

    [Benchmark]
    public void RNL1MNodes()
    {
        tree1M.RemoveNearestNodes();
    }
}

