using System.Text.RegularExpressions;
using static Lab1.BinaryTree;

namespace Lab1;

public class BinaryTreeGenerator
{
    public static BinaryTree FromArray(int?[] arr) // генерация дерева из массива (null - нет узла)
    {
        if (arr is null || arr[0] is null)
        {
            return new BinaryTree();
        }

        BinaryTree binaryTree = new()
        {
            Root = new Node((int)arr[0]!) // устанавливаем первое значение массива корнем
        };

        PopulateTreeFromArray(binaryTree.Root, arr); // проходим рекурсивно по всем значениям в массиве (будущим узлам)

        return binaryTree;
    }

    public static BinaryTree FromTextFile(string path)
    {
        string stringTree = string.Empty;

        try
        {
            stringTree = File.ReadAllText(path);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Environment.Exit(-1);
        }

        // удаление лишних символов в строке
        stringTree = Regex.Replace(stringTree, "\r?\n", " ");
        stringTree = Regex.Replace(stringTree, "  *", " ");

        return FromArray(stringTree.Split(' ').Select(n => //разделяем строку файла по пробелу, приводим к массиву целых чисел, по нему создаём дерево
        {
            if (int.TryParse(n, out int res))
            {
                return res;
            }
            
            int? res2 = null;
            return res2;
        }).ToArray());
    }

    private static void PopulateTreeFromArray(Node node, int?[] arr, int pos = 0)
    {
        if (node is null || arr is null || arr.Length == 0)
        {
            return;
        }

        int newPos = 2 * pos + 1; // Устанавливаем левое поддерево от текущего узла, + 1 т.к. корень мы уже задали в FromArray

        if (newPos < arr.Length && arr[newPos] is not null)
        {
            node.LeftNode = new Node((int)arr[newPos]!);
            PopulateTreeFromArray(node.LeftNode, arr, newPos);
        }

        newPos = 2 * pos + 2; // Устанавливаем правое поддерево от текущего узла, + 2 т.к. корень мы уже задали в FromArray

        if (newPos < arr.Length && arr[newPos] is not null)
        {
            node.RightNode = new Node((int)arr[newPos]!);
            PopulateTreeFromArray(node.RightNode, arr, newPos);
        }
    }
}
