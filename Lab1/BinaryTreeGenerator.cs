using System.Text.RegularExpressions;
using static Lab1.BinaryTree;

namespace Lab1;

internal class BinaryTreeGenerator
{
    // We will discard all the negative values as empty spaces
    public static BinaryTree FromArray(int?[] arr)
    {
        if (arr == null || arr[0] == null)
        {
            return new BinaryTree();
        }

        BinaryTree binaryTree = new BinaryTree
        {
            // We will populate the root node here
            // and leave the responsibility of populating rest of tree
            // to the recursive function
            Root = new Node((int)arr[0])
        };

        PopulateTreeFromArray(binaryTree.Root, arr, 0);

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

    private static void PopulateTreeFromArray(Node r, int?[] arr, int pos)
    {
        if (r is null || arr is null || arr.Length == 0)
        {
            return;
        }

        // Setting the left subtree of root
        int newPos = 2 * pos + 1;

        if (newPos < arr.Length && arr[newPos] != null)
        {
            r.LeftNode = new Node((int)arr[newPos]);
            PopulateTreeFromArray(r.LeftNode, arr, newPos);
        }

        // Setting the Right subtree of root
        newPos = 2 * pos + 2;

        if (newPos < arr.Length && arr[newPos] != null)
        {
            r.RightNode = new Node((int)arr[newPos]);
            PopulateTreeFromArray(r.RightNode, arr, newPos);
        }
    }
}
