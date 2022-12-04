using static Lab2.NAryTree;
using System.Text;

namespace Lab2;

internal static class NAryTreeSerializer
{
    public static string Serialize(Node root)
    {
        StringBuilder sb = new StringBuilder();
        if (root != null)
        {
            sb.Append(root.Value).Append(",");
            foreach (Node child in root.Children)
            {
                sb.Append(Serialize(child));
            }
            sb.Append(")");
        }
        return sb.ToString();
    }

    public static Node Deserialize(string str)
    {
        Node root = null;
        Stack<Node> stack = new Stack<Node>();
        StringBuilder data = new StringBuilder();

        for (int i = 0; i < str.Length; i++)
        {
            if (str.ElementAt(i) == ',')
            {
                Node child = new Node(int.Parse(data.ToString()));
                if (!(stack.Count == 0)) stack.Peek().AddChild(child);
                else root = child;
                stack.Push(child);
                data = new StringBuilder();
            }
            else if (str.ElementAt(i) == ')')
            {
                stack.Pop();
            }
            else
            {
                data.Append(str.ElementAt(i));
            }
        }

        return root;
    }
}
