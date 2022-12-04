using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using static Lab2.NAryTree;

namespace Lab2;

public class NAryTree
{
    public class Node
    {
        public int Value { get; set; }
        public List<Node> Children { get; set; } = new List<Node>();

        public Node(int value)
        {
            Value = value;
        }

        public Node(int value, List<Node> children)
            : this(value)
        {
            Children = children;
        }

        public void AddChild(Node child)
        {
            this.Children.Add(child);
        }
    }

    public Node? Root;

    public void Traverse(Node root)
    {
        if (root is not null)
        {
            Console.Write($"{root.Value} ");
            if (root.Children is not null)
            {
                for (int i = 0; i < root.Children.Count; i++)
                {
                    Traverse(root.Children[i]);
                }
            }
        }
    }

    public void RemoveNearestNodes()
    {
        List<List<Node>> nodes = new List<List<Node>>();

        foreach (var path in GetShortestPaths(Root))
        {
            RemoveLeaf(path);
        }
    }

    private void RemoveLeaf(List<Node> path)
    {
        Node current = Root;

        for (int i = 0; i < path.Count; i++)
        {
            for (int j = 0; j < current.Children.Count; j++)
            {
                if (current.Children[j].Value == path[i].Value)
                {
                    if (i == path.Count - 1)
                    {
                        current.Children.RemoveAt(j);
                    }
                    else
                    {
                        current = current.Children[j];
                    }
                }
            }
        }
    }

    public static List<List<Node>> GetShortestPaths(Node root)
    {
        List<List<Node>> allPaths = new List<List<Node>>();
        GetAllPaths(ref allPaths, root, new Stack<Node>());

        foreach (var item in allPaths)
        {
            item.Reverse();
        }

        int minLen = int.MaxValue;

        foreach (var item in allPaths)
        {
            if (item.Count < minLen)
            {
                minLen = item.Count;
            }
        }

        return allPaths.Where(n => n.Count == minLen).ToList();
    }

    private static List<List<Node>> GetAllPaths(ref List<List<Node>> paths, Node node, Stack<Node> path)
    {
        path.Push(node);
        if (node.Children.Count == 0)
        {
            paths.Add(path.ToList());
            path.Pop();
        }   
        else
        {
            foreach (Node child in node.Children)
            {
                GetAllPaths(ref paths, child, path);
            }

            path.Pop();
        }

        return paths;
    }

    public static int CountNodes(Node root)
    {
        if (root is null)
        {
            return 0;
        }

        int count = 1;

        foreach (Node child in root.Children)
        {
            count += CountNodes(child);
        }

        return count;
    }
}