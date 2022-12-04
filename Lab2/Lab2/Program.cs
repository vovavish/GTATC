using Lab2;

NAryTree deserializeTree = new NAryTree();

deserializeTree.Root = NAryTreeSerializer.Deserialize("0,5,3,)8,24,))4,)2,5,)))6,0,77,)))17,5,3,)7,0,)))");

NAryTreePrinter.PrintTree(deserializeTree.Root);
Console.WriteLine();
Console.WriteLine(NAryTreeSerializer.Serialize(deserializeTree.Root));

Console.WriteLine();
Console.WriteLine();

PrintPaths(NAryTree.GetShortestPaths(deserializeTree.Root));

deserializeTree.RemoveNearestNodes();
Console.WriteLine();
Console.WriteLine();
NAryTreePrinter.PrintTree(deserializeTree.Root);
Console.WriteLine();
Console.WriteLine();
PrintPaths(NAryTree.GetShortestPaths(deserializeTree.Root));

void PrintPaths(List<List<NAryTree.Node>> paths)
{
    foreach (var item in paths)
    {
        for (int i = 0; i < item.Count; i++)
        {
            Console.Write(item[i].Value + " ");
        }

        Console.WriteLine();
    }
}