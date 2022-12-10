using static Lab2.NAryTree;

namespace Lab2;

internal static class NAryTreePrinter
{
    private static int _minPathLen = 0;
    private static ConsoleColor _leafColor;


    public static void PrintTree(Node root, ConsoleColor leaf)
    {
        _leafColor = leaf;

        _minPathLen = GetShortestPaths(root)[0].Count - 1; // получаем длину самого коротко пути, чтобы обозначить нужные узлы цветом

        bool[] flag = new bool[CountNodes(root)];
        Array.Fill(flag, true);
        PrintNTree(root, flag, 0, false);
    }

    private static void PrintNTree(Node x, bool[] flag, int depth, bool isLast)
    {
        if (x is null)
        {
            return;
        }

        for (int i = 1; i < depth; ++i)
        {
            if (flag[i] == true)
            {
                Console.Write("|");
            }

            Console.Write("    ");
        }

        if (depth == _minPathLen && (x.Children is null || x.Children.Count == 0))
        {
            Console.ForegroundColor = _leafColor;
        }

        if (depth == 0)
        {
            Console.WriteLine(x.Value);
        }
        else if (isLast)
        {
            Console.Write("+--- " + x.Value + '\n');
            flag[depth] = false;
        }
        else
        {
            Console.Write("+--- " + x.Value + '\n');
        }

        Console.ResetColor();

        int it = 0;
        foreach (Node i in x.Children)
        {
            ++it;

            PrintNTree(i, flag, depth + 1, it == (x.Children.Count) - 1);
        }
        flag[depth] = true;
    }
}
