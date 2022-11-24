using System.Collections.Generic;

namespace Lab1;

public class BinaryTree
{
    public class Node
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

    public List<int> PrefixOrder() => (_root == null) ? new List<int>() : PrefixOrder(_root);

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

    public void SortedArrayToBST(int[] nums)
    {
        _root = Solve(0, nums.Length - 1);

        Node Solve(int low, int high)
        {
            if (low > high) return null;

            int mid = low + (high - low) / 2;
            return new Node(nums[mid], Solve(low, mid - 1), Solve(mid + 1, high));
        }
    }

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
        TreePrinter.LongestOddPath = LongestOddPath();
        _root.Print();
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

        List<int> leftPath = LongestOddPath(root.LeftNode);

        List<int> rightPath = LongestOddPath(root.RightNode);

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
}