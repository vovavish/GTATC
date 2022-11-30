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

    public List<Node> LongestOddPath() // обёртка над рекурсивным вызовом этого метода.
    {
        List<Node> result = LongestOddPath(Root);

        result.Reverse(); // реверсируем список, т.к. узлы добавляются в обратном порядке в рекурсивном вызове.

        return result;
    }

    public int HeightOfTree(Node? root) => root is null ? 0 : Math.Max(HeightOfTree(root.LeftNode), HeightOfTree(root.RightNode)) + 1;

    private List<Node> LongestOddPath(Node? root)
    {
        if (root is null || root.Value % 2 == 0) // если это лист или значение чётно, то возвращаем пустой список
        {
            return new List<Node>();
        }

        List<Node> leftPath = LongestOddPath(root.LeftNode); // проходим левое поддерево

        List<Node> rightPath = LongestOddPath(root.RightNode); // проходим правое поддерево

        if (leftPath.Count > rightPath.Count) // возвращаясь смотрим, где путь длиннее и добавляем очередное значение
        {
            leftPath.Add(root);
        }
        else
        {
            rightPath.Add(root);
        }

        return (leftPath.Count > rightPath.Count) ? leftPath : rightPath; // возвращаем больший путь
    }
}