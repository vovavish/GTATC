namespace Lab1;

class Program
{
    private static BinaryTree? _tree;

    public static void Main(string[] args)
    {
        if (args.Length == 0 || args[0].ToLower() == "help")
        {
            PrintHelp();
        }
        else if (args.Length == 1)
        {
            _tree = BinaryTreeGenerator.FromTextFile(args[0]);

            PrintTree(_tree);

            Console.WriteLine();

            List<BinaryTree.Node> longestPath = _tree.LongestOddPath();

            Console.WriteLine("Height of the tree: " + _tree.HeightOfTree(_tree.Root));

            string longestPathStr = LongestPathToStr(longestPath);

            Console.Write("Longest Odd Path: ");

            if (longestPathStr.Length > 60) // если путь в консоли не уместиться в 80 символов, то самый длинный путь записываем в файл
            {
                using (StreamWriter streamWriter = new($"tree_LongestPath_{longestPath.Count}.txt"))
                {
                    streamWriter.WriteAsync(longestPathStr);
                }

                Console.WriteLine($"written to file tree_LongestPath_{longestPath.Count}.txt");
            }
            else
            {
                Console.WriteLine(longestPathStr);
            }

            Console.WriteLine("Longest Odd Path Length: " + longestPath.Count);
        }
        else if (args.Length > 2)
        {
            if (int.TryParse(args[1], out int nNodes)) // парсим количество узлов
            {
                if (nNodes > 0)
                {
                    bool onlyOdd = false;

                    if (args[2][0].ToString().ToLower() == "y") // устанавливаем генерацию только нечётных чисел в соответствии с флагом в аргументах
                    {
                        onlyOdd = true;
                    }

                    BinaryTreeFileGenerator.GenFile(args[0], nNodes, onlyOdd);
                }
            }
            else
            {
                Console.WriteLine("Invalid Number of nodes.");
            }
        }
        else
        {
            Console.WriteLine("Try again.");
        }
    }

    static string LongestPathToStr(List<BinaryTree.Node> longestPath)
    {
        string longestPathToFile = string.Empty;

        for (int i = 0; i < longestPath.Count; i++)
        {
            longestPathToFile += longestPath[i].Value;

            if (i != longestPath.Count - 1)
            {
                longestPathToFile += " ";
            }
        }

        return longestPathToFile;
    }

    static void PrintTree(BinaryTree tree) // вывод дерева в случае, если оно поместиться в консоль
    {
        if (BinaryTreePrinter.CanPrint(tree))
        {
            BinaryTreePrinter.Print(tree);
        }
        else
        {
            Console.WriteLine("The tree is too big to print.");
        }
    }

    static void PrintHelp()
    {
        Console.WriteLine("Generate tree file:");
        Console.WriteLine("pathToSavefileTree numberOfNodes onlyOdd");
        Console.WriteLine("onlyOdd if > 0");
        Console.WriteLine();
        Console.WriteLine("See info about tree:");
        Console.WriteLine("pathTofileTree");
    }
}
