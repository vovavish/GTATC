using Lab2;

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

bool TryPrintTree(NAryTree tree)
{
    if (NAryTree.CountNodes(tree.Root) < 128)
    {
        NAryTreePrinter.PrintTree(tree.Root, ConsoleColor.Green);
        return true;
    }
    
    Console.WriteLine("The tree is too big to print.");
    return false;
}