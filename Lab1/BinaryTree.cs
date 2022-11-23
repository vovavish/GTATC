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

    public void Print()
    {
        if (_root != null)
        {
            Print(_root, "", null);
        }
        else
        {
            throw new Exception("Tree is Empty!");
        }
    }

    public List<int> LongestOddPath()
    {
        List<int> answer = LongestOddPath(_root);
        answer.Reverse();
        return answer;
    }

    private List<int> LongestOddPath(Node? root)
    {
        if (root is null || root.Value % 2 == 0)
        {
            return new List<int>();
        }

        List<int> rightPath = LongestOddPath(root.RightNode);

        List<int> leftPath = LongestOddPath(root.LeftNode);

        if (leftPath.Count > rightPath.Count)
        {
            leftPath.Add(root.Value);
        }
        else
        {
            rightPath.Add(root.Value);
        }

        return (leftPath.Count > rightPath.Count) ? leftPath : rightPath;
    }

    private void Print(Node? startNode, string indent, string? side)
    {
        if (startNode is not null)
        {
            Console.WriteLine($"{indent}[{side ?? "root"}]:{startNode.Value}");

            indent += new string(' ', 3);

            Print(startNode.LeftNode, indent, "L");
            Print(startNode.RightNode, indent, "R");
        }
    }
}