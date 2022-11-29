using System.Text.RegularExpressions;
using static Lab1.BinaryTree;

namespace Lab1;

public class BinaryTreeGenerator
{
    public static BinaryTree FromArray(int?[] arr)
    {
        if (arr == null || arr[0] == null)
        {
            return new BinaryTree();
        }

        BinaryTree binaryTree = new()
        {
            Root = new Node((int)arr[0]!)
        };

        PopulateTreeFromArray(binaryTree.Root, arr);

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

        stringTree = Regex.Replace(stringTree, "\r?\n", " ");
        
        int?[] arrayTree = stringTree.Split(' ').Select(n =>
        {
            if (int.TryParse(n, out int res))
            {
                return res;
            }
            
            int? res2 = null;
            return res2;
        }).ToArray();

        return FromArray(arrayTree);
    }

    private static void PopulateTreeFromArray(Node node, int?[] arr, int pos = 0)
    {
        if (node is null || arr is null || arr.Length == 0)
        {
            return;
        }

        // Setting the left subtree of root
        int newPos = 2 * pos + 1;

        if (newPos < arr.Length && arr[newPos] is not null)
        {
            node.LeftNode = new Node((int)arr[newPos]!);
            PopulateTreeFromArray(node.LeftNode, arr, newPos);
        }

        // Setting the Right subtree of root
        newPos = 2 * pos + 2;

        if (newPos < arr.Length && arr[newPos] is not null)
        {
            node.RightNode = new Node((int)arr[newPos]!);
            PopulateTreeFromArray(node.RightNode, arr, newPos);
        }
    }
}
