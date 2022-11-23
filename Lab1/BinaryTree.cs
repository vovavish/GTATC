namespace Lab1;

public class BinaryTree
{
    internal class Node
    {
        public int Value { get; set; }
        public Node? LeftNode { get; private set; }
        public Node? RightNode { get; private set; }

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

        public void Add(int value)
        {
            Node addNode = new Node(value);

            if (addNode.Value == Value)
            {
                return;
            }
            else if (addNode.Value < Value)
            {
                if (LeftNode == null)
                {
                    LeftNode = addNode;
                }
                else
                {
                    LeftNode.Add(value);
                }
            }
            else
            {
                if (RightNode == null)
                {
                    RightNode = addNode;
                }
                else
                {
                    RightNode.Add(value);
                }
            }
        }
    }

    private Node? _root;

    public void Add(int value)
    {
        if (_root == null)
        {
            _root = new Node(value);
            return;
        }

        _root.Add(value);
    }

    //public List<int> LongestOddPath()
    //{

    //}

    //private List<int> LongestOddPath(Node? startNode, int level)
    //{

    //}

    public void Print()
    {
        if (_root != null)
        {
            Print(_root);
        }
    }

    public List<int> PrefixOrder() => (_root == null) ? new List<int>() : PrefixOrder(_root);

    private void Print(Node? startNode, string indent = "", string? side = null)
    {
        if (startNode != null)
        {
            Console.WriteLine($"{indent}[{side ?? "root"}]:{startNode.Value}");

            indent += new string(' ', 3);

            Print(startNode.LeftNode, indent, "L");
            Print(startNode.RightNode, indent, "R");
        }
    }

    private List<int> PrefixOrder(Node node)
    {
        List<int> result = new List<int>();

        if (node != null)
        {
            result.Add(node.Value);

            if (node.LeftNode != null)
            {
                result.AddRange(PrefixOrder(node.LeftNode));
            }

            if (node.RightNode != null)
            {
                result.AddRange(PrefixOrder(node.RightNode));
            }
        }

        return result;
    }
}