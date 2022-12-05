namespace Lab2;

internal static class NAryTreeGenerator
{
    private readonly static Random rand = new(Environment.TickCount);

    public static NAryTree Generate(int depth, int minNChildren, int maxNChildren)
    {
        NAryTree tree = new NAryTree();
        GenerateFromNode(ref tree.Root, depth - 1, minNChildren, maxNChildren);
        return tree;
    }

    private static void GenerateFromNode(ref NAryTree.Node node, int needDepth, int minNChildren, int maxNChildren)
    {
        if (needDepth <= 0)
        {
            return;
        }

        if (node is null)
        {
            node = new NAryTree.Node(rand.Next(-50, 50));
        }

        if (node.Children is null)
        {
            node.Children = new List<NAryTree.Node>();
        }

        int nChildren = rand.Next(minNChildren, maxNChildren);
        for (int i = 0; i < nChildren; i++)
        {
            node.Children.Add(new NAryTree.Node(rand.Next(-50, 50)));
            NAryTree.Node child = node.Children[i];
            GenerateFromNode(ref child, needDepth - 1, minNChildren, maxNChildren);
        }
    }
}
