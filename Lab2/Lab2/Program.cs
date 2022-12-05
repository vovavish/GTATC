using Lab2;
using static System.Net.Mime.MediaTypeNames;

//NAryTree deserializeTree = NAryTreeGenerator.Generate(18,2, 2);
//NAryTree deserializeTree = new NAryTree();
//deserializeTree.Root = NAryTreeSerializer.Deserialize("5,7,2,)4,3,))6,7,)9,)4,)))3,0,-7,))0,74,)))5,4,)3,13,))6,)");
//NAryTreePrinter.PrintTree(deserializeTree.Root, ConsoleColor.Cyan);

if (args.Length != 1)
{
    Console.WriteLine("Enter Path to NAryTree.");
}
else
{
    NAryTree tree = NAryTreeSerializer.Deserialize(File.ReadAllText(args[0]));

    TryPrintTree(tree);

    tree.RemoveNearestNodes();
    Console.WriteLine();
    Console.WriteLine("Removal of nearest leaves to the root...");
    Console.WriteLine();
    if (TryPrintTree(tree) == false)
    {
        string pathToSave = $"RemovedNearestLeafs_{NAryTree.CountNodes(tree.Root)}Nodes.txt";
        Console.WriteLine($"Result writing in file: {pathToSave}");
        File.WriteAllText(pathToSave, NAryTreeSerializer.Serialize(tree.Root));
    }
}


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

bool TryPrintTree(NAryTree tree)
{
    if (NAryTree.CountNodes(tree.Root) < 30)
    {
        NAryTreePrinter.PrintTree(tree.Root, ConsoleColor.Green);
        return true;
    }
    else
    {
        Console.WriteLine("The tree is too big to print.");
        return false;
    }
}