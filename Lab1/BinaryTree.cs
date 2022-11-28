using System.Collections.Generic;

namespace Lab1;

public class BinaryTree
{
    public class Node
    {
        public int Value { get; set; }
        public Node? LeftNode { get; set; }
        public Node? RightNode { get; set; }

        public Node() {}

        public Node(int value)
        {
            Value = value;
        }

        public Node(int value, Node? leftNode, Node rightNode)
            : this(value)
        {
            LeftNode = leftNode;
            RightNode = rightNode;
        }
    }

    public Node? Root { get; set; }

    //////////////////////////////////////////////
    public int HeightOfTree(Node? root)
    {
        return root is null ? 0 : Math.Max(HeightOfTree(root.LeftNode), HeightOfTree(root.RightNode)) + 1;
    }

    // Traverse the tree in inorder and keep storing
    // each node at right place in the array arr.
    // Initial value of pos is 0
    void PopulateNodesInArray(Node r, int[] arr, int pos)
    {
        if (r == null)
        {
            return;
        }

        arr[pos] = r.Value;
        
        if (r.LeftNode != null)
        {
            PopulateNodesInArray(r.LeftNode, arr, 2 * pos + 1);
        }

        if (r.RightNode != null)
        {
            PopulateNodesInArray(r.RightNode, arr, 2 * pos + 2);
        }
    }

    public int[] ToArray()
    {
        int[] arr = new int[(int)Math.Pow(2, HeightOfTree(Root)) - 1];

        Array.Fill(arr, -1);

        PopulateNodesInArray(Root, arr, 0);

        return arr;
    }

    // pos is the position of root in array
    public void PopulateTreeFromArray(Node r, int[] arr, int pos)
    {
        if (r == null || arr == null || arr.Length == 0)
        {
            return;
        }

        // Setting the left subtree of root
        int newPos = 2 * pos + 1;

        if (newPos < arr.Length && arr[newPos] != -1)
        {
            r.LeftNode = new Node(arr[newPos]);
            PopulateTreeFromArray(r.LeftNode, arr, newPos);
        }

        // Setting the Right subtree of root
        newPos = 2 * pos + 2;

        if (newPos < arr.Length && arr[newPos] != -1)
        {
            r.RightNode = new Node(arr[newPos]);
            PopulateTreeFromArray(r.RightNode, arr, newPos);
        }
    }

    // We will discard all the negative values as empty spaces
    public void FromArray(int[] arr)
    {
        if (arr == null || arr[0] == -1)
        {
            return;
        }

        // We will populate the root node here
        // and leave the responsibility of populating rest of tree
        // to the recursive function
        Root = new Node(arr[0]);
        PopulateTreeFromArray(Root, arr, 0);
    }
    //////////////////////////////////////////////

    public void Print()
    {
        TreePrinter.LongestOddPath = LongestOddPath();
        Root.Print();
    }

    public List<Node> LongestOddPath()
    {
        List<Node> answer = LongestOddPath(Root);
        answer.Reverse();
        return answer;
    }

    private List<Node> LongestOddPath(Node? root)
    {
        if (root is null || root.Value % 2 == 0)
        {
            return new List<Node>();
        }

        List<Node> leftPath = LongestOddPath(root.LeftNode);

        List<Node> rightPath = LongestOddPath(root.RightNode);

        if (leftPath.Count > rightPath.Count)
        {
            leftPath.Add(root);
        }
        else
        {
            rightPath.Add(root);
        }

        return (leftPath.Count > rightPath.Count) ? leftPath : rightPath;
    }
}