namespace Lab1;

public class BinaryTree
{
    public class Node
    {
        public int Value { get; set; }
        public Node? LeftNode { get; set; }
        public Node? RightNode { get; set; }

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

    private void PopulateNodesInArray(Node? node, int[] arr, int pos = 0)
    {
        if (node == null)
        {
            return;
        }

        arr[pos] = node.Value;
        
        if (node.LeftNode != null)
        {
            PopulateNodesInArray(node.LeftNode, arr, 2 * pos + 1);
        }

        if (node.RightNode != null)
        {
            PopulateNodesInArray(node.RightNode, arr, 2 * pos + 2);
        }
    }

    public int[] ToArray()
    {
        int[] arr = new int[(int)Math.Pow(2, HeightOfTree(Root)) - 1];

        Array.Fill(arr, -1);

        PopulateNodesInArray(Root, arr);

        return arr;
    }

    public List<Node> LongestOddPath()
    {
        List<Node> result = LongestOddPath(Root);

        result.Reverse();

        return result;
    }

    public List<Node> LongestOddPath(Node? root)
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

    private int HeightOfTree(Node? root) => root is null ? 0 : Math.Max(HeightOfTree(root.LeftNode), HeightOfTree(root.RightNode)) + 1;
}