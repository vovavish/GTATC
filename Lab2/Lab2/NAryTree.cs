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

    public void RemoveNearestNodes() // удаление самых близких к корню листов
    {
        List<List<Node>> nodes = GetShortestPaths(Root);

        foreach (var path in nodes)
        {
            RemoveLeaf(ref Root, path);
        }
    }

    private void RemoveLeaf(ref Node node, List<Node> path) // удаление листа по конкретному пути
    {
        if (node is null || path.Count <= 0)
        {
            return;
        }

        Node current = node;

        for (int i = 1; i < path.Count; i++)
        {
            for (int j = 0; j < current.Children.Count; j++)
            {
                if (current.Children[j].Value == path[i].Value)
                {
                    if (i == path.Count - 1 && (current.Children[j].Children is null || current.Children[j].Children.Count == 0)) // если ребёнок текущего узла лист
                    {
                        current.Children.RemoveAt(j); // удаляем его
                    }
                    else
                    {
                        Node from = current.Children[j];

                        RemoveLeaf(ref from, path.Skip(i).ToList()); // для каждого ребёнка, который подойдёт нам для следующего рекурсивно вызываем удаление пути
                    }
                }
            }
        }
    }

    public static List<List<Node>> GetShortestPaths(Node root) // получение самых коротких путей
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

        return allPaths.Where(n => n.Count == minLen).ToList(); // из всех путей выбираем самые короткие
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
}