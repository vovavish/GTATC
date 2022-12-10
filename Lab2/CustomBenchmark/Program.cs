using Lab2;
using System.Diagnostics;

string tree15serialize = File.ReadAllText(@"..\..\..\tree15.txt");
string tree1kserialize = File.ReadAllText(@"..\..\..\tree1k.txt");
string tree260kserialize = File.ReadAllText(@"..\..\..\tree260k.txt");
string tree1Mserialize = File.ReadAllText(@"..\..\..\tree1M.txt");

NAryTree tree15 = NAryTreeSerializer.Deserialize(tree15serialize);
NAryTree tree1k = NAryTreeSerializer.Deserialize(tree1kserialize);
NAryTree tree260k = NAryTreeSerializer.Deserialize(tree260kserialize);
NAryTree tree1M = NAryTreeSerializer.Deserialize(tree1Mserialize);

BenchmarkTime(RNL15NWithTreeDeserialize, false);
BenchmarkMemory(RNL15NWithTreeDeserialize, false);

BenchmarkTime(RNL1kNWithTreeDeserialize, false);
BenchmarkMemory(RNL1kNWithTreeDeserialize, false);

BenchmarkTime(RNL260kNWithTreeDeserialize, false);
BenchmarkMemory(RNL260kNWithTreeDeserialize, false);

BenchmarkTime(RNL1MNWithTreeDeserialize, false);
BenchmarkMemory(RNL1MNWithTreeDeserialize, false);

BenchmarkTime(RNL15Nodes, false);
BenchmarkMemory(RNL15Nodes, false);

BenchmarkTime(RNL1kNodes, false);
BenchmarkMemory(RNL1kNodes, false);

BenchmarkTime(RNL260kNodes, false);
BenchmarkMemory(RNL260kNodes, false);

BenchmarkTime(RNL1MNodes, false);
BenchmarkMemory(RNL1MNodes, false);



BenchmarkTime(RNL15NWithTreeDeserialize, true);
BenchmarkMemory(RNL15NWithTreeDeserialize, true);
Console.WriteLine();
BenchmarkTime(RNL1kNWithTreeDeserialize, true);
BenchmarkMemory(RNL1kNWithTreeDeserialize, true);
Console.WriteLine();
BenchmarkTime(RNL260kNWithTreeDeserialize, true);
BenchmarkMemory(RNL260kNWithTreeDeserialize, true);
Console.WriteLine();
BenchmarkTime(RNL1MNWithTreeDeserialize, true);
BenchmarkMemory(RNL1MNWithTreeDeserialize, true);
Console.WriteLine();
BenchmarkTime(RNL15Nodes, true);
BenchmarkMemory(RNL15Nodes, true);
Console.WriteLine();
BenchmarkTime(RNL1kNodes, true);
BenchmarkMemory(RNL1kNodes, true);
Console.WriteLine();
BenchmarkTime(RNL260kNodes, true);
BenchmarkMemory(RNL260kNodes, true);
Console.WriteLine();
BenchmarkTime(RNL1MNodes, true);
BenchmarkMemory(RNL1MNodes, true);

void BenchmarkTime(Operation op, bool print)
{
    Stopwatch sw = new Stopwatch();

    sw.Start();
    op();
    sw.Stop();

    if (print)
    {
        Console.WriteLine(op.Method.Name + " " + (sw.Elapsed.TotalMilliseconds * 1000) + " us");
    }
}

void BenchmarkMemory(Operation op, bool print)
{
    GC.Collect();
    long START = GC.GetTotalAllocatedBytes(false);
    op();
    long bytes = GC.GetTotalAllocatedBytes(false) - START;

    if (print)
    {
        Console.WriteLine(op.Method.Name + " " + bytes + " B");
    }
}

void RNL15NWithTreeDeserialize()
{
    NAryTree tree15 = NAryTreeSerializer.Deserialize(tree15serialize);
    tree15.RemoveNearestNodes();
}

void RNL1kNWithTreeDeserialize()
{
    NAryTree tree1k = NAryTreeSerializer.Deserialize(tree1kserialize);
    tree1k.RemoveNearestNodes();
}

void RNL260kNWithTreeDeserialize()
{
    NAryTree tree260k = NAryTreeSerializer.Deserialize(tree260kserialize);
    tree260k.RemoveNearestNodes();
}

void RNL1MNWithTreeDeserialize()
{
    NAryTree tree1M = NAryTreeSerializer.Deserialize(tree1Mserialize);
    tree1M.RemoveNearestNodes();
}


void RNL15Nodes()
{
    tree15.RemoveNearestNodes();
}

void RNL1kNodes()
{
    tree1k.RemoveNearestNodes();
}

void RNL260kNodes()
{
    tree260k.RemoveNearestNodes();
}

void RNL1MNodes()
{
    tree1M.RemoveNearestNodes();
}

delegate void Operation();